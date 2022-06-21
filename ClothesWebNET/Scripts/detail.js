//--------------------------DETAIL-----------------------------

//---xử lý chọn size---
let btnSizes = document.querySelectorAll(".detail-size .size"); //mấy cái nút size
let btnAddCart = document.querySelector(".detail-button-add-cart");

const removeAllSizeActive = (btnSizes) => {
  btnSizes.forEach((size) => {
    if (size.classList.contains("size-active"))
      size.classList.remove("size-active");
  });
};

for (let i = 0; i < btnSizes.length; i++) {
    btnSizes[i].addEventListener("click", (e) => {
        document.querySelector(".input-amout").value = 1;
      removeAllSizeActive(btnSizes);
    
    btnSizes[i].classList.add("size-active");
  });
}

const getSize = () => {
  let selectSize = null;
  btnSizes.forEach((size) => {
    if (size.classList.contains("size-active"))
      selectSize = size.textContent.trim();
  });
  return selectSize;
};



let ttttMoney = document.querySelector('.payment-total');

btnAddCart.addEventListener("click", (e) => {

  let size = getSize();
  if (size != null) {
    let img = document.querySelector("#imagebox").src;
    let priceFake = document.querySelector(".total-money").textContent;
    let price = Number(priceFake.slice(0, 3).trim());
    let title = document.querySelector(".detail-title").textContent;
      let amount = document.querySelector(".input-amout").value;
      let idFood = document.querySelector('.idFood').textContent;
      let id = 0
      let data = { id, title, price, size, img, amount, idFood};

    var cart = window.localStorage.getItem("cart");
    if (cart === null) {
      window.localStorage.setItem("cart", JSON.stringify([data]));
    } else {
      const listCart = JSON.parse(window.localStorage.getItem("cart"));

        listCart.forEach((el) => {
       
        if (el["title"] === data["title"]) {
          if (el["size"] === data["size"]) {
            const listCartAmount = Number(el["amount"]);
            const dataAmount = Number(data["amount"]);

            el["amount"] = listCartAmount + dataAmount;
          } else {
          }
        } else {
          const cartFake = listCart.find((el2) => {
            return el["title"] === el2["title"];
          });
            if (!cartFake) {
                data['id'] = Number(listCart.length);
            listCart.push(data);
          }
        }
      });

      let dataSize = listCart.find((el) => {
        return el["title"] === data["title"] && el["size"] === data["size"];
      });
      if (!dataSize) {
        data['id'] = Number(listCart.length);
        listCart.push(data);
      }
      window.localStorage.setItem("cart", JSON.stringify(listCart));
      }
      let cartList = JSON.parse(window.localStorage.getItem('cart'));
      renderIconCart(cartList)
      $('.cart-count').html(cartList.length)
      $('.header-top-cart-box').addClass('header-top-modal-show')
     /* ShowSucces();*/
    /*  location.reload();*/
  
    

    
      
  } else ShowErr("Bạn chưa chọn size")
});



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
                                                <div class="info-item-pice">${el['price']},000đ</div>
                                            </div>
                                        </div>
                                    </div>
                `
            total += intoMoney
            str += bodyCart
        });

        if (count > 0) {
            ttttMoney.innerHTML = total.toLocaleString() + ",000 VND";
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


function ShowSucces() {
    toastr["success"]("Thêm vào giỏ hàng thành công")

    toastr.options = {
        "closeButton": false,
        "debug": false,
        "newestOnTop": false,
        "progressBar": false,
        "positionClass": "toast-top-right",
        "preventDuplicates": false,
        "onclick": null,
        "showDuration": "300",
        "hideDuration": "300",
        "timeOut": "300",
        "extendedTimeOut": "300",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    }
}

function ShowErr(mess) {
    toastr["error"](mess)

    toastr.options = {
        "closeButton": false,
        "debug": false,
        "newestOnTop": false,
        "progressBar": false,
        "positionClass": "toast-top-right",
        "preventDuplicates": false,
        "onclick": null,
        "showDuration": "300",
        "hideDuration": "300",
        "timeOut": "300",
        "extendedTimeOut": "300",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    }
}