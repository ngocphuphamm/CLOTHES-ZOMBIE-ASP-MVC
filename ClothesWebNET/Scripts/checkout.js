const formInfo = document.querySelector('.form-info');
const fullname = document.getElementById('fullname');
const email = document.getElementById('email');
const phone = document.getElementById('phone');
const address = document.getElementById('address');

const city = document.getElementById('province');
const district = document.getElementById('district');
const ward = document.getElementById('village');

fetch('/data.json')
    .then((response) => response.json())
    .then((data) => renderCity(data));

function renderCity(data) {
    for (var item of data) {
        // kh?i t?o ra ??i t??ng các t?nh thành ph?
        city.options[city.options.length] = new Option(item.Name, item.Id);
    }

    // x? lý khi thay ??i t?nh thành thì s? hi?n th? ra qu?n huy?n thu?c t?nh thành ?ó
    city.onchange = () => {
        district.length = 1;

        console.log(city.value);
        // ki?m tra giá tr? value xem có r?ng ko là none thì ko th?c hi?n render các qu?n ra
        if (city.value != '') {
            // l?c ra d? li?u khi ng??i dùng tr? vào t?nh thành ph?
            const result = data.filter((n) => n.Id === city.value);
            // nguyên nhân result[0].District
            // gi?i thích :
            // thì lúc ta l?c d? li?u result xong thì k?t qu? nó s? tr? cho ra m?t m?ng
            // trong m?ng ?ó ch?a ??i t??ng [{}]
            // thì có ph?i ??i t??ng mình g?i trong ?ó ?ang ? index = 0 thì mình ph?i g?i nó ra
            // là
            //   result[0] thì lúc này nó ra  object{} thì trong object mình g?i ??n attribute là DISTRICTS
            //     => result[0].Districts
            for (var item of result[0].Districts) {
                district.options[district.options.length] = new Option(
                    item.Name,
                    item.Id
                );
            }
        } else {
            // do nothing
        }
    };

    district.onchange = () => {
        ward.length = 1;
        const result = data.filter((el) => el.Id === city.value);
        if (district.value != ' ') {
            // l?y d? li?u qu?n và trong d? li?u qu?n ch? tên ???ng
            const resultDistrict = result[0].Districts.filter(
                (el) => el.Id === district.value
            );

            for (var item of resultDistrict[0].Wards) {
                ward.options[ward.options.length] = new Option(item.Name, item.id);
            }
        }
    };
}
// renderCity(dt);
import validation from './validation.js';

//submit form
formInfo.addEventListener('submit', function (e) {
    e.preventDefault();
    let checkEmpty = validation.checkRequired([fullname, email, phone, address]);
    let checkEmailInvalid = validation.checkEmail(email);
    let checkPhoneInvalid = validation.checkNumberPhone(phone);
    let checkAddressInvalid = validation.checkAddress([city, district, ward]);

    if (
        checkEmpty &&
        checkEmailInvalid &&
        checkPhoneInvalid &&
        checkAddressInvalid
    )
        alert('oke bro');
});