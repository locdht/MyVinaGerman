using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmitMapper;
using EmitMapper.MappingConfiguration;
using EmitMapper.MappingConfiguration.MappingOperations;
using EmitMapper.Utils;
using System.Data;
using System.Reflection;
namespace SupportCenter.DataSource.Implementation.Utils
{
    public class DataReaderToObjectMapper<T> : ObjectsMapper<IDataReader, T>
    {
        class DbReaderMappingConfig : IMappingConfigurator
        {
            IEnumerable<string> _skipFields;
            public DbReaderMappingConfig(IEnumerable<string> skipFields)
            {
                _skipFields = skipFields == null ? new List<string>() : skipFields;
            }

            public IRootMappingOperation GetRootMappingOperation(Type from, Type to)
            {
                return null;
            }

            private ValueGetter<T> GetValuesGetter(int ind, MemberInfo m)
            {
                var memberType = ReflectionUtils.GetMemberType(m);
                Func<object, object> converter = StaticConvertersManager.DefaultInstance.GetStaticConverterFunc(typeof(object), memberType);
                if (converter == null)
                {
                    throw new EmitMapperException("Could not convert an object to " + memberType.ToString());
                }
                int fieldNum = -1;
                return
                    (value, state) =>
                    {
                        var reader = ((IDataReader)state);
                        if (fieldNum == -1)
                        {
                            fieldNum = reader.GetOrdinal(m.Name);
                        }
                        object result = reader[fieldNum];

                        if (result is DBNull)
                        {
                            return ValueToWrite.ReturnValue(null);
                        }
                        return ValueToWrite.ReturnValue(converter(result));
                    };
            }

            public IMappingOperation[] GetMappingOperations(Type from, Type to)
            {
                return ReflectionUtils
                    .GetPublicFieldsAndProperties(to)
                    .Where(
                        m => m.MemberType == MemberTypes.Field ||
                            m.MemberType == MemberTypes.Property && ((PropertyInfo)m).GetSetMethod() != null
                    )
                    .Where(m => !_skipFields.Select(sf => sf.ToUpper()).Contains(m.Name.ToUpper()))
                    .Select(
                        (m, ind) =>
                            new DestWriteOperation()
                            {
                                Destination = new MemberDescriptor(new[] { m }),
                                Getter = GetValuesGetter(ind, m)
                            }
                    )
                    .ToArray();
            }

            public string GetConfigurationName()
            {
                return "dbreader_";
            }

            public StaticConvertersManager GetStaticConvertersManager()
            {
                return null;
            }
        }

        public DataReaderToObjectMapper(
            ObjectMapperManager mapperManager,
            IEnumerable<string> skipFields)
            : base(GetMapperImpl(mapperManager, skipFields))
        {
        }

        public DataReaderToObjectMapper(ObjectMapperManager mapperManager)
            : this(mapperManager, null)
        {
        }

        public DataReaderToObjectMapper()
            : this(null, null)
        {
        }

        public DataReaderToObjectMapper(IEnumerable<string> skipFields)
            : this(null, skipFields)
        {
        }

        public T ReadSingle(IDataReader reader)
        {
            return ReadSingle(reader, null);
        }

        public T ReadSingle(IDataReader reader, ObjectsChangeTracker changeTracker)
        {
            T result = reader.Read() ? MapUsingState(reader, reader) : default(T);
            if (changeTracker != null)
            {
                changeTracker.RegisterObject(result);
            }
            return result;
        }

        public IEnumerable<T> ReadCollection(IDataReader reader)
        {
            return ReadCollection(reader, null);
        }

        public IEnumerable<T> ReadCollection(IDataReader reader, ObjectsChangeTracker changeTracker)
        {
            while (reader.Read())
            {
                T result = MapUsingState(reader, reader);
                if (changeTracker != null)
                {
                    changeTracker.RegisterObject(result);
                }
                yield return result;
            }
            reader.Close();
        }

        private static ObjectsMapperBaseImpl GetMapperImpl(
            ObjectMapperManager mapperManager,
            IEnumerable<string> skipFields)
        {
            IMappingConfigurator config = new DbReaderMappingConfig(skipFields);

            if (mapperManager != null)
            {
                return mapperManager.GetMapperImpl(
                    typeof(IDataReader),
                    typeof(T),
                    config);
            }
            else
            {
                return ObjectMapperManager.DefaultInstance.GetMapperImpl(
                    typeof(IDataReader),
                    typeof(T),
                    config);
            }
        }
    }
}
