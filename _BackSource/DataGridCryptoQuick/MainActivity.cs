using Android.App;
using Android.Widget;
using Android.OS;
using Syncfusion.SfDataGrid;
using Android.Views;

namespace $safeprojectname$
{
	[Activity (Label = "SfDataGrid", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		SfDataGrid sfGrid;
        OrderInfoRepository viewModel;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Main);
			ActionBar.SetDisplayShowHomeEnabled (false);

			RelativeLayout layout = (RelativeLayout)FindViewById (Resource.Id.Relative);
            viewModel = new OrderInfoRepository();
            sfGrid = new SfDataGrid (BaseContext);
            sfGrid.AllowSorting = true;
            sfGrid.ItemsSource = (viewModel.OrderInfoCollection);
            sfGrid.VerticalOverScrollMode = VerticalOverScrollMode.None;
            

            sfGrid.GroupColumnDescriptions.Add(new GroupColumnDescription() { ColumnName = "ShipCountry" }); 

			sfGrid.AutoGeneratingColumn += HandleAutoGeneratingColumn;
			layout.AddView (sfGrid);
		}

        void HandleAutoGeneratingColumn(object sender, AutoGeneratingColumnEventArgs e)
        {
            if (e.Column.MappingName == "CustomerID")
                e.Column.TextAlignment = GravityFlags.CenterVertical;
            else if (e.Column.MappingName == "CustomerName")
                e.Column.TextAlignment = GravityFlags.CenterVertical;
        }
	}
}


