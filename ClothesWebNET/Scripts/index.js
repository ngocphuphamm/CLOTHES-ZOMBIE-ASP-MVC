//ẩn hiện modal
const listActions = document.querySelectorAll('.header-top-link');
const modals = document.querySelectorAll('.header-top-modal');

const removeAllClassShowModal = (modals) => {
  modals.forEach((item) => {
    if (item.classList.contains('header-top-modal-show'))
      item.classList.remove('header-top-modal-show');
  });
};

listActions.forEach((item) => {
  item.addEventListener('click', (e) => {
    let parent = item.parentElement;
    let modalShow = parent.querySelector('.header-top-modal');
    if (modalShow.classList.contains('header-top-modal-show'))
      modalShow.classList.remove('header-top-modal-show');
    else {
      removeAllClassShowModal(modals);
      modalShow.classList.add('header-top-modal-show');
    }
  });
});

const btnResetPassword = document.getElementById('modal-reset-password');
const modalResetPassword = document.querySelector('.reset-password-box');
const btnBackLogin = document.getElementById('modal-back-login');
const modalLogin = document.querySelector('.header-top-login-box');

//hiện form quên mật khẩu

//trở về đăng nhập


//chuyển hướng vào giỏ hàng &thanh toán
let btnViewCart = document.querySelector('.box-view-cart');
btnViewCart.addEventListener('click', (e) => {
  window.location = '/cart';
});

let btnViewCheckout = document.querySelector('.box-make-payment');
btnViewCheckout.addEventListener('click', (e) => {
  window.location = '/cart/checkout';
});




//ẩn hiện form register





let iconCloseModalRegister = document.querySelector('.icon-close');

iconCloseModalRegister.addEventListener('click', (e) => {
    modalOverplay.click();
});

let iconClick = document.querySelectorAll('.box-triangle');

iconClick.forEach(i => {
    i.addEventListener('click', e => {
        removeAllClassShowModal(modals)
    })
})


let ips = document.querySelector('.input-search-box');
let btnS = document.querySelector('.btn-search');
ips.addEventListener('keypress', e => {
    if (e.keyCode == 13)
        btnS.click();
})

btnS.addEventListener('click', e => {

    let vl = ips.value.trim();
    if (vl != "") {
        let url = `/search/index?q=${vl}`
        window.location = url;
    }

})