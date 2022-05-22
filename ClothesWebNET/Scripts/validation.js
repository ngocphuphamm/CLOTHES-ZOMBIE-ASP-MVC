//hiển thị lỗi
function showError(input, message) {
    const parent = input.parentElement;
    parent.classList.add('err');
    const small = parent.querySelector('small');
    small.innerText = message;
}

//tắt lỗi
function showSuccess(input) {
    const parent = input.parentElement;
    if (parent.classList.contains('err')) {
        parent.classList.remove('err');
        const small = parent.querySelector('small');
        small.innerText = ' ';
    }
}

function getPlaceholder(input) {
    return input.getAttribute('placeholder');
}
class Validation {
    //kiểm tra chưa nhập
    checkRequired(inputArr) {
        let isRequired = true;
        inputArr.forEach(function (input) {
            if (input.value.trim() === '') {
                showError(input, `${getPlaceholder(input)} không được trống`);
                isRequired = false;
            } else {
                showSuccess(input);
            }
        });
        return isRequired;
    }

    //kiểm tra email hợp lệ
    checkEmail(input) {
        let check = false;
        const re =
            /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;

        if (re.test(input.value.trim())) {
            showSuccess(input);
            check = true;
        } else {
            showError(input, 'Email không hợp lệ');
        }
        return check;
    }

    checkNumberPhone(input) {
        let check = false;
        let regex =
            /^(0?)(3[2-9]|5[6|8|9]|7[0|6-9]|8[0-6|8|9]|9[0-4|6-9])[0-9]{7}$/;
        if (regex.test(input.value.trim())) {
            showSuccess(input);
            check = true;
        } else {
            showError(input, 'Số điện thoại không hợp lệ');
        }
        return check;
    }
    checkPasswordMatches(inputPass1, inputPass2) {
        let check = false;
        let pass1 = inputPass1.value.trim();
        let pass2 = inputPass2.value.trim();
        if (pass1 == pass2) {
            check = true;
            showSuccess(inputPass2);
        } else {
            showError(inputPass2, 'Mật khẩu không khớp');
        }
        return check;
    }

    //kiểm tra tỉnh thành phố quận huyện xã
    checkAddress(selectArr) {
        let check = false;
        selectArr.forEach(function (select) {
            if (select.value.trim() == 'invalid') {
                showError(select, `Bạn chưa chọn ${getPlaceholder(select)}`);
                check = true;
            } else {
                showSuccess(select);
            }
        });
        return check;
    }
}
export default new Validation();
