var headerList = document.getElementById('headerList');
function sort(el) {
    
    headerList.innerHTML = '<tr><th><span id="thName" onclick="sort(this)">Name</span></th>' +
        '<th><span id="thSurname" onclick="sort(this)">Surname</span></th>' +
        '<th><span id="thPatronymic"onclick="sort(this)">Patronymic</span></th>' +
        '<th><span id="thPassportNumber"onclick="sort(this)">Passport number</span></th>' +
        '<th><span id="thSex"onclick="sort(this)">Sex</span></th>' +
        '<th><span id="thBirthday"onclick="sort(this)">Birthday</span></th>' +
        '<th><span id="thCity"onclick="sort(this)">City</span></th>' +
        '<th><span id="thAddress"onclick="sort(this)">Address</span>' +
        '</th><th><span id="thIssuedBy"onclick="sort(this)">Issued by</span></th>' +
        '<th><span id="thDateOfIssue"onclick="sort(this)">Date of issue</span></th>' +
        '<th><span id="thCode"onclick="sort(this)">Code</span></th></tr>';
    var elem = document.getElementById(el.id);
    elem.innerHTML += "<i class='icon-chevron-down icon-white'/>";
    var id = 0;
    switch (el.id) {
        case 'thName':
            id = 1;
            break;
        case 'thSurname':
            id = 2;
            break;
        case 'thPatronymic':
            id = 3;
            break;
        case 'thPassportNumber':
            id = 4;
            break;
        case 'thSex':
            id = 5;
            break;
        case 'thBirthday':
            id = 6;
            break;
        case 'thCity':
            id = 7;
            break;
        case 'thAddress':
            id = 8;
            break;
        case 'thIssuedBy':
            id = 9;
            break;
        case 'thDateOfIssue':
            id = 10;
            break;
        case 'thCode':
            id = 11;
            break;
        
    default:
    }
    Search(id);

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

function Search(id) {

    var label = document.getElementById('labe');
    var headerList = document.getElementById('headerList');
    var xhr = new XMLHttpRequest;

    var passportData = {
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
    var url = "/api/passport?json=" + (JSON.stringify(passportData)).toString() + "&id="+id;
    xhr.open("GET", url, true);
    xhr.setRequestHeader('Content-type', 'application/json');
    xhr.send(JSON.stringify(passportData));
    var load = document.getElementById('search');
    load.innerHTML = '<img id="load" src="/img/loading22.gif"/>';

    xhr.onload = function() {
        if (xhr.readyState == 4 && xhr.status == 200) {
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
                    headerList.innerHTML = '<tr><th><span id="thName" onclick="sort(this)">Name</span></th><th><span id="thSurname" onclick="sort(this)">Surname</span></th><th><span id="thPatronymic"onclick="sort(this)">Patronymic</span></th><th><span id="thPassportNumber"onclick="sort(this)">Passport number</span></th><th><span id="thSex"onclick="sort(this)">Sex</span></th><th><span id="thBirthday"onclick="sort(this)">Birthday</span></th><th><span id="thCity"onclick="sort(this)">City</span></th><th><span id="thAddress"onclick="sort(this)">Address</span></th><th><span id="thIssuedBy"onclick="sort(this)">Issued by</span></th><th><span id="thDateOfIssue"onclick="sort(this)">Date of issue</span></th><th><span id="thCode"onclick="sort(this)">Code</span></th></tr>';

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