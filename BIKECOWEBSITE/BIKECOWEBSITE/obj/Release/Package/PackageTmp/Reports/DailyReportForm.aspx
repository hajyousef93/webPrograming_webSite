<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DailyReportForm.aspx.cs" Inherits="BIKECOWEBSITE.Reports.DailyReportForm" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <script src="~/Scripts/jquery-1.10.2.min.js"></script>
    <title>BIKECO Report</title>
      <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css"/>
    <script src="Scripts/jquery-1.10.2.min.js"></script>
        <link href="~/Content/bootstrap.min.css" rel="stylesheet" />
    <script src="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.3.1/js/bootstrap.bundle.min.js"></script>
        <script src="~/Scripts/bootstrap.min.js"></script>
    <style type="text/css">
        .navbar-toggle {
            width: 127px;
        }
        ul {
  list-style-type: none;
  margin: 0;
  padding: 0;
  overflow: hidden;
  background-color: #222;
  height:53px;
}

li {
  float: left;
}

li a {
  display: block;
  color: #9d9d9d;
  text-align: center;
  padding: 13px 62px;
  text-decoration: none;
  font-size:18px;

}

li a:hover {
    color:white;
    height:53px;

}
footer.ex1 {
            color: white;
            background-color: #222;
            height: 80px;
            white-space: nowrap;
            overflow: hidden;
            text-align: center;
            min-height: 100%;
            bottom: 0;
            width: 100%;
}
    </style>
</head>
<body">
  <ul >
    <li><a class="active" href="../Home/Index" style="text-decoration:none">BIKE_CO</a></li>
  </ul>
        
    <center>   
        <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <rsweb:ReportViewer ID="ReportViewer1" Width="900px" runat="server" BackColor="" ClientIDMode="AutoID" HighlightBackgroundColor="" InternalBorderColor="204, 204, 204" InternalBorderStyle="Solid" InternalBorderWidth="1px" LinkActiveColor="" LinkActiveHoverColor="" LinkDisabledColor="" PrimaryButtonBackgroundColor="" PrimaryButtonForegroundColor="" PrimaryButtonHoverBackgroundColor="" PrimaryButtonHoverForegroundColor="" SecondaryButtonBackgroundColor="" SecondaryButtonForegroundColor="" SecondaryButtonHoverBackgroundColor="" SecondaryButtonHoverForegroundColor="" SplitterBackColor="" ToolbarDividerColor="" ToolbarForegroundColor="" ToolbarForegroundDisabledColor="" ToolbarHoverBackgroundColor="" ToolbarHoverForegroundColor="" ToolBarItemBorderColor="" ToolBarItemBorderStyle="Solid" ToolBarItemBorderWidth="1px" ToolBarItemHoverBackColor="" ToolBarItemPressedBorderColor="51, 102, 153" ToolBarItemPressedBorderStyle="Solid" ToolBarItemPressedBorderWidth="1px" ToolBarItemPressedHoverBackColor="153, 187, 226" Height="471px">
                <LocalReport ReportPath="Reports\DailyReport.rdlc">
                    <DataSources>
                        <rsweb:ReportDataSource Name="DataSet1" DataSourceId="SqlDataSource2"></rsweb:ReportDataSource>
                    </DataSources>
                </LocalReport>
            </rsweb:ReportViewer>

            <asp:SqlDataSource runat="server" ID="SqlDataSource2" ConnectionString='<%$ ConnectionStrings:ADMDataBaseConnectionString3 %>' SelectCommand="SELECT YEAR(DateOfPurchase) AS Sales_Year, MONTH(DateOfPurchase) AS Sales_Month, DAY(DateOfPurchase) AS Sales_Day, SUM(PriseOfOrder) AS TotalSales FROM Orders GROUP BY YEAR(DateOfPurchase), MONTH(DateOfPurchase), DAY(DateOfPurchase) ORDER BY Sales_Year, Sales_Month, Sales_Day"></asp:SqlDataSource>
        </div>
    </form>
</center>
</body>
     <hr />

        <footer class="ex1">
            <br>
            &copy; <%= DateTime.Now.Year %> - Powered by AWP & ADM Team
             <p>DONE BY:
            Mhd_Mohsen_121343
            Mohammad_121485
            Ahmad_121295</p>
        </footer>

</html>
