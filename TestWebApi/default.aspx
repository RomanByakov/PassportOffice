<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" 
         Inherits="TestWebApi.WebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>PassportOffice</title>
        <div style="background-color: black"><h1 style="color: white; text-align: center">PassportOffice</h1><input style="position: absolute; top: 15px; right: 10px" id="SignIn" type="button" value="Siqn In" class="btn" onclick=" document.location.replace('/admin.aspx'); "/></div>
        
        <link rel="stylesheet" type="text/css" href="/Styles/Style.css"/>
        <link rel="stylesheet" type="text/css" href="/Styles/bootstrap.min.css"/>
        <link rel="stylesheet" type="text/css" href="/Styles/datepicker3.css"/>
    </head>
    <body>
        <script src="/Scripts/jquery-1.8.3.min.js"></script>
        <script src="/Scripts/bootstrap.js"></script>
        
        <script src="/Scripts/bootstrap-datepicker.js"></script>

        <form id="form1" runat="server" style="padding-top: 30px; margin: auto;">
            <div>
                
                <table id="table" style="text-align: right; margin: auto;">
                    <tr>
                        <td>Name:
                            <div class="input-prepend"><span class="add-on"><i class="icon-user"></i></span><input class="span2" id="Name" type="text" placeholder="Иван"/>
                            </div></td>
                        <td>Passport number:
                            <div class="input-prepend"><span class="add-on"><i class="icon-book"></i></span><input class="span2" id="PassportNumber" type="text"placeholder="2406282193"/>
                            </div></td>
                        <td>City:
                            <div class="input-prepend"><span class="add-on"><i class="icon-map-marker"></i></span><input class="span2" id="City" type="text" placeholder="Иваново"/>
                            </div></td>
                        <td>Date of issue:
                            <div class="input-prepend"><span class="add-on"><i class="icon-calendar"></i></span><input class="span2"  data-date-format="yyyy-mm-dd" id="DateOfIssue" type="text" placeholder="2014-01-01"/>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>Surname:
                            <div class="input-prepend"><span class="add-on"><i class="icon-tag"></i></span><input class="span2" id="Surname" type="text" placeholder="Иванов"/>
                            </div></td>
                        <td>Sex:
                            <div class="input-prepend"><span class="add-on"><i class="icon-eye-open"></i></span><select id="Sex" class="span2" >
                                                                                                                    <option></option>
                                                                                                                    <option>male</option>
                                                                                                                    <option>female</option>

                                                                                                                </select>
                            </div></td>
                        <td>Address:
                            <div class="input-prepend"><span class="add-on"><i class="icon-home"></i></span><input class="span2" id="Address" type="text" placeholder="ул.Ивановская"/>
                            </div></td>
                        <td>Code:
                            <div class="input-prepend"><span class="add-on"><i class="icon-barcode"></i></span><input class="span2" id="Code" type="text" placeholder="111-111"/>
                            </div></td>
                    </tr>
                    <tr>
                        <td>Patronymic:
                            <div class="input-prepend"><span class="add-on"><i class="icon-tags"></i></span><input class="span2" id="Patronymic" type="text" placeholder="Иванович"/>
                            </div></td>
                        <td>Birthday:
                            <div class="input-prepend"><span class="add-on"><i class="icon-calendar"></i></span><input data-date-format="yyyy-mm-dd" class="span2" id="Birthday" type="text" placeholder="2014-01-01"/>
                            </div></td>
                        <td>Issued by:
                            <div class="input-prepend"><span class="add-on"><i class="icon-flag"></i></span><input class="span2" id="IssuedBy" type="text" placeholder="ОВД Лениского района"/>
                            </div></td>
                        <td><input id="search" type="button" value="Search" onclick="javascript: document.getElementById('headerList').innerHTML = ''; document.getElementById('testList').innerHTML = ''; Search(2, true);" class="btn"/> </td>
                    </tr>
                </table>

            </div>
            <center><span id="labe" class="table"></span></center> 
            <table class="table table-striped">
                <thead id="headerList"></thead>
                <tbody id="testList">

                </tbody>
            </table>
            <div id="loadmoreajaxloader" style="display:none;"><center><img src='\img\loadings.gif' /></center></div>
            <div id="countRow" style="display:none;">0</div>
        </form>
        <script src="/Scripts/default.js"></script>
    
    </body>
</html>