var passportData;
var direction = true;
var sort = 1;
var count = document.getElementById('countRow');
window.onscroll = function() {
    var top = $(document).height();
    
    var body = document.body,
    html = document.documentElement;

    var top2 = Math.max(body.scrollHeight, body.offsetHeight,
                           html.clientHeight, html.scrollHeight, html.offsetHeight);


    var w = $(window).height();
    var w2 = window.innerHeight;
    var scroll = $(window).scrollTop();
    var scroll2 = window.scrollY;
    debugger;
    if (/*$(window).scrollTop()*/window.scrollY == /*$(document).height()*/Math.max(body.scrollHeight, body.offsetHeight,
                           html.clientHeight, html.scrollHeight, html.offsetHeight) - /*$(window).height()*/window.innerHeight) {
        document.getElementById('loadmoreajaxloader').style.display = 'block';
        var countRow = parseInt(document.getElementById('countRow').innerHTML);
        count.innerHTML = countRow + 20;
        var skip = parseInt(document.getElementById('countRow').innerHTML);
        var xhr = new XMLHttpRequest;
        var url = "/api/passport?passportObjectJson=" + (JSON.stringify(passportData)).toString() + "&sort=" + sort + "&direction=" + direction + "&skip=" + skip;
        xhr.open("GET", url, true);
        xhr.setRequestHeader('Content-type', 'application/json');
        xhr.send(null);
        xhr.onload = function() {
            if (xhr.readyState == 4 && xhr.status == 200) {
                var html = JSON.parse(xhr.responseText);
                var include = '';
                            for (var i = 0; i < html.length; i++) {

                                var row = '<tr><td>' + html[i].Name + '</td><td>' + html[i].Surname + '</td><td>' + html[i].Patronymic + '</td><td>' + html[i].PassportNumber + '</td><td>' + html[i].Sex + '</td><td>' + html[i].Birthday.substr(0, html[i].Birthday.indexOf("T")) + '</td><td>' + html[i].City + '</td><td>' + html[i].Address + '</td><td>' + html[i].IssuedBy + '</td><td>' + html[i].DateOfIssue.substr(0, html[i].Birthday.indexOf("T")) + '</td><td>' + html[i].Code + '</td></tr>';
                                include += row;
                            }
                document.getElementById('testList').innerHTML += include;
                document.getElementById('loadmoreajaxloader').style.display = 'none';
            }
        };
        
    }
}

var headerList = document.getElementById('headerList');
function Sorting(el) {
    sort = 0;
    direction = true;
    debugger;
    var elemenWithRowDown = document.getElementsByClassName('icon-chevron-down icon-white')[0];
    var elemenWithRowUp = document.getElementsByClassName('icon-chevron-up icon-white')[0];
    
    headerList.innerHTML = '<tr><th><span id="thName" onclick="Sorting(this)">Name</span></th><th><span id="thSurname" onclick="Sorting(this)">Surname</span></th><th><span id="thPatronymic"onclick="Sorting(this)">Patronymic</span></th><th><span id="thPassportNumber"onclick="Sorting(this)">Passport number</span></th><th><span id="thSex"onclick="Sorting(this)">Sex</span></th><th><span id="thBirthday"onclick="Sorting(this)">Birthday</span></th><th><span id="thCity"onclick="Sorting(this)">City</span></th><th><span id="thAddress"onclick="Sorting(this)">Address</span></th><th><span id="thIssuedBy"onclick="Sorting(this)">Issued by</span></th><th><span id="thDateOfIssue"onclick="Sorting(this)">Date of issue</span></th><th><span id="thCode"onclick="Sorting(this)">Code</span></th></tr>';

    var elem = document.getElementById(el.id);
    elem.innerHTML += "<i id='icon' class='icon-chevron-down icon-white'/>";
    if (elemenWithRowDown) {
        if (elemenWithRowDown.parentNode == el) {
            direction = false;
            document.getElementById(elemenWithRowDown.id).setAttribute('class', 'icon-chevron-up icon-white');
        }
    }
    if (elemenWithRowUp) {
        if (elemenWithRowUp.parentNode == el) {
            direction = true;
            document.getElementById(elemenWithRowUp.id).setAttribute('class', 'icon-chevron-down icon-white');
        }
    }

    switch (el.id) {
        case 'thName':
            sort = 1;
            break;
        case 'thSurname':
            sort = 2;
            break;
        case 'thPatronymic':
            sort = 3;
            break;
        case 'thPassportNumber':
            sort = 4;
            break;
        case 'thSex':
            sort = 5;
            break;
        case 'thBirthday':
            sort = 6;
            break;
        case 'thCity':
            sort = 7;
            break;
        case 'thAddress':
            sort = 8;
            break;
        case 'thIssuedBy':
            sort = 9;
            break;
        case 'thDateOfIssue':
            sort = 10;
            break;
        case 'thCode':
            sort = 11;
            break;
        
    default:
    }
    Search(sort, direction);

}
function Auth() {
    var title = document.getElementById('title');
    title.innerHTML = "Enter login and password";
    var xhr = new XMLHttpRequest;
    var url = "/api/user";
    xhr.open("post", url, true);
    var user = {
        Login: document.getElementById('login').value,
        Password: document.getElementById('password').value
    };
    xhr.setRequestHeader('Content-type', 'application/json');
    xhr.send(JSON.stringify(user));
    xhr.onload = function () {
        if (xhr.readyState == 4 && xhr.status == 200) {
            var html = "";
            var resp = JSON.parse(xhr.responseText);
            if (resp) {
                var doc = document.getElementById('popup1');
                doc.style.display = 'none';
            }
            else {
                title.innerHTML += "Wrong login or password";
            }

        }
        
    };
    
}
function PopUpShow() {
    var doc = document.getElementById('popup1');
    doc.style.display = 'block';
}



function PopUpHide() {
    document.location.replace('/default.aspx');
}

function Search(sort,direction,skip) {
    if (!skip) {
        skip = 0;
    }
    $('div#loadmoreajaxloader').show();
    count.innerHTML = 0;
    var label = document.getElementById('labe');
    var headerList = document.getElementById('headerList');
    var xhr = new XMLHttpRequest;

    passportData = {
        Name: document.getElementById('Name').value,
        Surname: document.getElementById('Surname').value,
        Patronymic: document.getElementById('Patronymic').value,
        PassportNumber: document.getElementById('PassportNumber').value,
        Sex: document.getElementById('Sex').value,
        Birthday: document.getElementById('Birthday').value,
        City: document.getElementById('City').value,
        Address: document.getElementById('Address').value,
        IssuedBy: document.getElementById('IssuedBy').value,
        DateOfIssue: document.getElementById('DateOfIssue').value,
        Code: document.getElementById('Code').value
    };
    var url = "/api/passport?passportObjectJson=" + (JSON.stringify(passportData)).toString() + "&sort=" + sort + "&direction=" + direction +"&skip=" + skip;
    xhr.open("GET", url, true);
    xhr.setRequestHeader('Content-type', 'application/json');
    xhr.send(JSON.stringify(passportData));
    var load = document.getElementById('search');
    load.innerHTML = '<img id="load" src="/img/loading22.gif"/>';

    xhr.onload = function() {
        if (xhr.readyState == 4 && xhr.status == 200) {
            $('div#loadmoreajaxloader').hide();
            var html = "";
            load.src = "";
            var resp = JSON.parse(xhr.responseText);
            var testList = document.getElementById('testList');
            if (resp.length == 0) {
                label.innerHTML = 'Sorry, not found';
                headerList.innerHTML = '';
                testList.innerHTML = '';
            } else {
                label.innerHTML = "";
                if (headerList.innerHTML.length == 0) {
                    headerList.innerHTML = '<tr><th><span id="thName" onclick="Sorting(this)">Name<i id="icon" class="icon-chevron-down icon-white"/></span></th><th><span id="thSurname" onclick="Sorting(this)">Surname</span></th><th><span id="thPatronymic"onclick="Sorting(this)">Patronymic</span></th><th><span id="thPassportNumber"onclick="Sorting(this)">Passport number</span></th><th><span id="thSex"onclick="Sorting(this)">Sex</span></th><th><span id="thBirthday"onclick="Sorting(this)">Birthday</span></th><th><span id="thCity"onclick="Sorting(this)">City</span></th><th><span id="thAddress"onclick="Sorting(this)">Address</span></th><th><span id="thIssuedBy"onclick="Sorting(this)">Issued by</span></th><th><span id="thDateOfIssue"onclick="Sorting(this)">Date of issue</span></th><th><span id="thCode"onclick="Sorting(this)">Code</span></th></tr>';
                }
                for (var i = 0; i < resp.length; i++) {

                    var row = '<tr><td>' + resp[i].Name + '</td><td>' + resp[i].Surname + '</td><td>' + resp[i].Patronymic + '</td><td>' + resp[i].PassportNumber + '</td><td>' + resp[i].Sex + '</td><td>' + resp[i].Birthday.substr(0, resp[i].Birthday.indexOf("T")) + '</td><td>' + resp[i].City + '</td><td>' + resp[i].Address + '</td><td>' + resp[i].IssuedBy + '</td><td>' + resp[i].DateOfIssue.substr(0, resp[i].Birthday.indexOf("T")) + '</td><td>' + resp[i].Code + '</td></tr>';
                    html += row;
                }


                testList.innerHTML = html;
            }

        }

    };
}