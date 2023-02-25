<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Beamer_shop.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Beamer Shop</title>
    <link href="styles.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
</head>
<body>
    <form id="form1" runat="server">
        <div class="mainwrap">

        <!-- Design lines trough page -->
        <div class="design-lines">
            <div id="left"></div>
            <div id="right"></div>
        </div>

        <!-- Navigation -->
        <div class="nav">
            <ul>
                <li style="font-weight:800"><a class="logo" href="#home">Beamer Shop</a></li>
                <li><a href="#home">Account</a></li>
                <li><a href="#news">About us</a></li>
                <li><a href="#contact">Cars</a></li>
                <li style="float: right"><a class="active" href="#about">Cart</a></li>
            </ul>
        </div>
        <!-- main center container -->
            <div class="center-main">

                <img id="landing-car" src="/Images/bmwi8-home.png" alt="Flowers in Chania" width="" height=""/>


                <div id="btnCollection">
                    <a href="#cars">View collection</a>
                </div>
            </div>

            <!-- footer -->
            <div class="foot">
                <div class="foot-left">
                    <h2>Follow us on social media!</h2>
                    <ul>
                        <li><a href="#" class="fa fa-instagram"></a></li>
                        <li><a href="#" class="fa fa-facebook"></a></li>
                        <li><a href="#" class="fa fa-linkedin"></a></li>
                    </ul>
                </div>
                <div class="foot-right">
                    <h2>Contact</h2>
                    <h3>Rachelsmolen 1, 5612 MA</h3>
                    <h3>Eindhoven, The Netherlands</h3>
                </div>
            </div>

        </div>
    </form>
</body>
</html>
