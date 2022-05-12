function showTime() {
    var date = new Date();
    var h = date.getHours(); // 0 - 23
    var m = date.getMinutes(); // 0 - 59
    var s = date.getSeconds(); // 0 - 59
    var session = 'AM';

    if (h == 0) {
        h = 12;
    }

    if (h > 12) {
        h = h - 12;
        session = 'PM';
    }

    h = h < 10 ? '0' + h : h;
    m = m < 10 ? '0' + m : m;
    s = s < 10 ? '0' + s : s;

    var time = h + ':' + m + ':' + s + ' ' + session;
    document.getElementById('MyClockDisplay').innerText = `Bây giờ là: ${time}`;
    document.getElementById('MyClockDisplay').textContent = `Bây giờ là: ${time}`;

    setTimeout(showTime, 1000);
}

showTime();

// Current Date
var today = new Date();
let date = `Ngày: ${today.getDate()}/${today.getMonth() + 1
    }/${today.getFullYear()}`;
document.getElementById('today').innerHTML = date;

let fname = document.querySelector('.icon-user-fullname');
let fullName = fname.textContent;
let nameSlice = fullName.slice(fullName.lastIndexOf(' ') + 1);
fname.innerHTML = `Hello, ${nameSlice} <i class='bx bx-chevron-down'></i>`;
