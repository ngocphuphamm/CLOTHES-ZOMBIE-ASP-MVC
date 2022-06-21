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
    const listCart = JSON.parse(window.localStorage.getItem('cart'));
    if (listCart.length >0) {
        window.location = '/bill';
    }
  
});




let info = document.querySelector('.info-name');
if (info) {

    fetch('/Home/GetUserInfo')
        .then(response => response.json())
        .then(data => {
            info.innerHTML = data.Result[0].fullName;
          /*  console.log(data.Result[0])*/
        });
}




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



//render giỏ hàng nhỏ
let listCartt = JSON.parse(window.localStorage.getItem('cart'));
let ttMoney = document.querySelector('.payment-total');


$('.cart-count').html(listCartt.length)

function renderIconCart(dataList) {
    $(document).ready(() => {
        let str = ''
        let total = 0
        let count = 0;

        if (dataList)
        dataList.forEach((el, index) => {
            count++;
            let intoMoney = Number(el['price']) * Number(el['amount'])
            let bodyCart = `
                          <div class="item-cart-product">
                                        <img src="${el['img']}" class="item-cart-product-img">
                                        <div class="item-cart-info">
                                            <div class="cart-info-item">
                                                <p class="info-item-title">${el['title']}</p>
                                                
                                            </div>
                                            <div class="cart-info-size">${el['size']}</div>
                                            <div class="cart-info-item">
                                                <div class="info-item-amount">${el['amount']}</div>
                                                <div class="info-item-pice">${el['price']},000₫</div>
                                            </div>
                                        </div>
                                    </div>
                `
            total += intoMoney
            str += bodyCart
        });

        if (count > 0) {
            ttMoney.innerHTML = total.toLocaleString() + ",000 VND";
            $('.box-item-cart').html(str)
        }
        else {
            let emp = `<div class="box-cart-empty">
                  <svg width="81" height="70" viewBox="0 0 81 70"><g transform="translate(0 2)" stroke-width="4" stroke="#1e2d7d" fill="none" fill-rule="evenodd"><circle stroke-linecap="square" cx="34" cy="60" r="6"></circle><circle stroke-linecap="square" cx="67" cy="60" r="6"></circle><path d="M22.9360352 15h54.8070373l-4.3391876 30H30.3387146L19.6676025 0H.99560547"></path></g></svg>
                 <div>Giỏ hàng của bạn đang trống</div>
                </div>`
            $('.box-item-cart').addClass('box-cart-empty')
            $('.box-item-cart').removeClass('box-item-cart')
            $('.box-cart-empty').html(emp);
        }


    })
}

renderIconCart(listCartt)