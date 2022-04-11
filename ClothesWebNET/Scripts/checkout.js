const formInfo = document.querySelector('.form-info');
const fullname = document.getElementById('fullname');
const email = document.getElementById('email');
const phone = document.getElementById('phone');
const address = document.getElementById('address');
const province = document.getElementById('province');
const district = document.getElementById('district');
const village = document.getElementById('village');

import validation from './validation.js';

//submit form
formInfo.addEventListener('submit', function (e) {
  e.preventDefault();
  let checkEmpty = validation.checkRequired([fullname, email, phone, address]);
  let checkEmailInvalid = validation.checkEmail(email);
  let checkPhoneInvalid = validation.checkNumberPhone(phone);
  let checkAddressInvalid = validation.checkAddress([
    province,
    village,
    district,
  ]);

  if (
    checkEmpty &&
    checkEmailInvalid &&
    checkPhoneInvalid &&
    checkAddressInvalid
  )
    alert('oke bro');
});
