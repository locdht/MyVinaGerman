using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VinaGerman.DesktopApplication.ViewModels.UserViews;

namespace VinaGerman.DesktopApplication.Views.UserViews
{
    /// <summary>
    /// Interaction logic for uvCustomerManagement.xaml
    /// </summary>
    public partial class uvPurchaseOrderDetail : UserControl
    {
        public uvPurchaseOrderDetail()
        {
            InitializeComponent();
        }
        #region ultilities
        private int GetDataGridItemCurrentRowIndex(DataGrid grid, GetDragDropPosition pos)
        {
            int currIndex = -1;
            for (int i = 0; i < grid.Items.Count; i++)
            {
                DataGridRow item = GetDataGridRowItem(grid, i);
                if (item != null && IsTheMouseOnTargetRow(item, pos))
                {
                    currIndex = i;
                    break;
                }
            }
            return currIndex;
        }
        private bool IsTheMouseOnTargetRow(Visual theTarget, GetDragDropPosition pos)
        {
            Rect posBounds = VisualTreeHelper.GetDescendantBounds(theTarget);
            Point theMousePos = pos((IInputElement)theTarget);
            return posBounds.Contains(theMousePos);
        }
        private DataGridRow GetDataGridRowItem(DataGrid grid, int index)
        {
            if (grid.ItemContainerGenerator.Status != GeneratorStatus.ContainersGenerated)
                return null;
            return grid.ItemContainerGenerator.ContainerFromIndex(index) as DataGridRow;
        }
        public void ScrollToNextRow(DataGrid grid)
        {
            if (grid.CurrentItem != null)
            {
                int currentRowIndex = grid.ItemContainerGenerator.IndexFromContainer(grid.ItemContainerGenerator.ContainerFromItem(grid.CurrentItem));

                if (currentRowIndex < grid.Items.Count - 1)
                {
                    GetRow(grid, currentRowIndex + 1).IsSelected = true;
                    MoveCellFocus(FocusNavigationDirection.Down);
                    //if this is the last row in the list, we need to move down one more time...
                    if ((currentRowIndex + 1) == (grid.Items.Count - 1))
                        MoveCellFocus(FocusNavigationDirection.Down);
                }
            }
        }

        public void ScrollToPreviousRow(DataGrid grid)
        {
            int currentRowIndex = grid.ItemContainerGenerator.IndexFromContainer(grid.ItemContainerGenerator.ContainerFromItem(grid.CurrentItem));

            if (currentRowIndex > 0)
            {
                GetRow(grid, currentRowIndex - 1).IsSelected = true;
                MoveCellFocus(FocusNavigationDirection.Up);
            }
        }
        //the below will handle Tab,Enter, Shift+Tab to improve keyboardinput
        private void MoveCellFocus(FocusNavigationDirection direction, int step = 1)
        {
            int count = 0;
            while (count < step)
            {
                UIElement uiElement = Keyboard.FocusedElement as UIElement;
                uiElement.MoveFocus(new TraversalRequest(direction));
                count++;
            }
        }
        #endregion

        #region Orderline grid        
        private void OrderlineGrid_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            uvPurchaseOrderDetailViewModel viewModel = (uvPurchaseOrderDetailViewModel)this.DataContext;
            var uiElement = e.OriginalSource as UIElement;

            if (uiElement != null)
            {
                if (e.Key == Key.Tab)
                {
                    if ((Keyboard.Modifiers & ModifierKeys.Shift) == ModifierKeys.Shift)
                    {
                        if (uiElement.Uid == "txtArticleNo")
                        {
                            ScrollToPreviousRow(OrderlineGrid);

                        }
                        else
                        {
                            MoveCellFocus(FocusNavigationDirection.Previous);
                        }
                    }
                    else
                    {
                        if (uiElement.Uid == "txtPayDate")
                        {
                            bool isCreated = CreateOrderline();
                            if (isCreated)
                            {
                                ScrollToNextRow(OrderlineGrid);
                                MoveCellFocus(FocusNavigationDirection.Left, 3);
                            }
                        }
                        else
                        {
                            MoveCellFocus(FocusNavigationDirection.Next);
                        }
                    }
                    e.Handled = true;
                }
                else if (e.Key == Key.Enter)
                {
                    bool isCreated = CreateOrderline();
                    if (isCreated)
                    {
                        ScrollToNextRow(OrderlineGrid);
                        if (uiElement.Uid == "txtPrice")
                        {
                            MoveCellFocus(FocusNavigationDirection.Left, 1);
                        }                        
                        else if (uiElement.Uid == "txtPayDate")
                        {
                            MoveCellFocus(FocusNavigationDirection.Left, 3);
                        }
                    }
                    e.Handled = true;
                }
            }

        }       
        public bool CreateOrderline()
        {
            uvPurchaseOrderDetailViewModel viewModel = (uvPurchaseOrderDetailViewModel)this.DataContext;
            //if (viewModel != null && viewModel.ValidateCopiedEquipment())
            //{
                viewModel.AddOrderline();
                return true;
            //}
            //return false;
        }


        public DataGridRow GetRow(DataGrid grid, int index)
        {
            grid.UpdateLayout();
            grid.ScrollIntoView(grid.Items[index]);
            DataGridRow row = (DataGridRow)grid.ItemContainerGenerator.ContainerFromIndex(index);
            //uvManageEquipmentViewModel viewModel = (uvManageEquipmentViewModel)this.DataContext;
            //if (viewModel != null)
            //{
            //    viewModel.SetSelectedCopiedEquipmentFromIndex(index);
            //}
            return row;
        }

        public static T GetVisualChild<T>(Visual parent) where T : Visual
        {
            T child = default(T);
            int numVisuals = VisualTreeHelper.GetChildrenCount(parent);
            for (int i = 0; i < numVisuals; i++)
            {
                Visual v = (Visual)VisualTreeHelper.GetChild(parent, i);
                child = v as T;
                if (child == null)
                {
                    child = GetVisualChild<T>(v);
                }
                if (child != null)
                {
                    break;
                }
            }
            return child;
        }

        //LocDHT: the below will auto focus on textbox  when click on row
        public delegate Point GetDragDropPosition(IInputElement theElement);
        private void OrderlineGrid_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            uvPurchaseOrderDetailViewModel viewModel = (uvPurchaseOrderDetailViewModel)this.DataContext;
            int previousIndex = OrderlineGrid.SelectedIndex;
            int currentIndex = GetDataGridItemCurrentRowIndex(OrderlineGrid, e.GetPosition);
            if (previousIndex >= 0 && currentIndex >= 0)
            {
                if (previousIndex > currentIndex)
                    MoveCellFocus(FocusNavigationDirection.Up, previousIndex - currentIndex);
                else
                    MoveCellFocus(FocusNavigationDirection.Down, currentIndex - previousIndex);
            }
            //viewModel.SetSelectedCopiedEquipmentFromIndex(currentIndex);
        }
        
        #endregion
    }
}
