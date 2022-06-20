let listCart = JSON.parse(window.localStorage.getItem('cart'));
let totalMoney = document.getElementById('totalMoney');
let qty = document.getElementById('qty');
let tttMoney = document.querySelector('.payment-total');
//render gi? hàng
function renderTable(dataList) {
    $(document).ready(() => {
        let str = ''
        let total = 0
        let count = 0;
        dataList.forEach((el, index) => {
            count++
            let intoMoney = Number(el['price']) * Number(el['amount'])
            let bodyCart = `
                     <div class="cart-product-item">
                            <img src="${el['img']}" alt="" class="item-img">
                            <div class="item-info">
                                <div class="info-heading">
                                    <div class="heading-title">${el['title']}</div>
                                    <div class="heading-close" onclick="remove('${el['title']}','${el['size']}',event)"><img src="//theme.hstatic.net/200000321771/1000699946/14/ic_close.png?v=305"></div>
                                </div>
                                <div class="info-price">${el['price']},000 VND</div>
                                <div class="info-price">${el['size']}</div>
                                <div class="info-total">
                                    <div class="total-amount">
                                        <button class="button-amount button-minus" onclick="clickMinus('${el['title']}','${el['size']}',event)"/>-</button>
                                        <input type="number" class="input-amout" readonly min="1" value="${el['amount']}" />
                                        <button class="button-amount button-add" onclick="clickAdd('${el['title']}','${el['size']}',event)">+</button>
                                    </div>
                                    <div class="total-money">
                                    ${intoMoney.toLocaleString()},000 VND
                                    </div>
                                </div>
                            </div>
                        </div>
            `
            total += intoMoney
            str += bodyCart
        })

        qty.innerHTML = count
        if (count > 0) {
            totalMoney.innerHTML = total.toLocaleString() + ",000 VND";
            $('#renderBody').html(str)
        }
        else {
            totalMoney.innerHTML = "0 VND";
            let emp = <div class="empty-cart">Ch?a có s?n ph?m nào tron gi? hàng</div>
            $('#renderBody').html(emp);

        }



    })
}
renderTable(listCart);
//render gi? hàng nh?
function renderIconCart(dataList) {
    $(document).ready(() => {
        let str = ''
        let total = 0
        let count = 0;

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
                                                <div class="info-item-pice">${el['price']},000?</div>
                                            </div>
                                        </div>
                                    </div>
                `
            total += intoMoney
            str += bodyCart
        });

        if (count > 0) {
            tttMoney.innerHTML = total.toLocaleString() + ",000 VND";
            $('.box-item-cart').html(str)
        }
        else {
            let emp = `<div class="box-cart-empty">
                  <svg width="81" height="70" viewBox="0 0 81 70"><g transform="translate(0 2)" stroke-width="4" stroke="#1e2d7d" fill="none" fill-rule="evenodd"><circle stroke-linecap="square" cx="34" cy="60" r="6"></circle><circle stroke-linecap="square" cx="67" cy="60" r="6"></circle><path d="M22.9360352 15h54.8070373l-4.3391876 30H30.3387146L19.6676025 0H.99560547"></path></g></svg>
                 <div>Gi? hàng c?a b?n còn tr?ng</div>
                </div>`
            $('.box-item-cart').addClass('box-cart-empty')
            $('.box-item-cart').removeClass('box-item-cart')
            $('.box-cart-empty').html(emp);
        }


    })
}



function clickMinus(title, size, e) {
    let cart = JSON.parse(window.localStorage.getItem('cart'));
    cart.forEach((el) => {
        if (el['title'] === title && el['size'] === size) {
            if (el['amount'] > 1) {
                el['amount'] -= 1;
            }
            else {
                alert("S? l??ng gi?m trên 1")
            }

        }
    })
    window.localStorage.setItem('cart', JSON.stringify(cart));
    let total = 0
    listCart.forEach((el) => {
        let intoMoney = Number(el['price']) * Number(el['amount'])
        total += intoMoney
    })
    totalMoney.innerHTML = total.toLocaleString() + ",000 VND";
    renderTable(cart);
}
function clickAdd(title, size, e) {
    let cart = JSON.parse(window.localStorage.getItem('cart'));
    cart.forEach((el) => {
        if (el['title'] === title && el['size'] === size) {

            el['amount'] += 1;


        }
    })
    window.localStorage.setItem('cart', JSON.stringify(cart));

    renderTable(cart);
}
function remove(title, size, e) {
    let cart = JSON.parse(window.localStorage.getItem('cart'));
    const cartNew = cart.filter((el) => {

        return el['title'] !== title
    })
    cartNew.filter((el) => {
        return el['size'] !== size
    })
    window.localStorage.setItem('cart', JSON.stringify(cartNew));

    //render l?i
    renderTable(cartNew);
    //render cart nh?
    renderIconCart(cartNew)
}
$('.button-payment').click(() => {
    window.location.href = '/bill'
})