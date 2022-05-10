//--------------------------DETAIL-----------------------------

//---xử lý chọn size---
let btnSizes = document.querySelectorAll('.detail-size .size'); //mấy cái nút size
let btnAddCart = document.querySelector('.detail-button-add-cart');

const removeAllSizeActive = (btnSizes) => {
  btnSizes.forEach((size) => {
    if (size.classList.contains('size-active'))
      size.classList.remove('size-active');
  });
};

for (let i = 0; i < btnSizes.length; i++) {
  btnSizes[i].addEventListener('click', (e) => {
    removeAllSizeActive(btnSizes);
    btnSizes[i].classList.add('size-active');
  });
}

const getSize = () => {
  let selectSize = null;
  btnSizes.forEach((size) => {
    if (size.classList.contains('size-active'))
      selectSize = size.textContent.trim();
  });
  return selectSize;
};

let price = document.querySelector('.total-money').textContent;

btnAddCart.addEventListener('click', (e) => {
    let size = getSize();
    if (size != null) {
        let img = document.querySelector('#imagebox').src;
        let totalMoney = document.querySelector('.total-money').textContent;
        let title = document.querySelector('.detail-title').textContent;
        let amount = document.querySelector('.input-amout').value;
        let data = { title, price, totalMoney, size, img, amount };

        var cart = window.localStorage.getItem('cart');
        if (cart === null) {
            window.localStorage.setItem('cart', JSON.stringify([data]));

        }
        else {
            const listCart = JSON.parse(window.localStorage.getItem('cart'));
          
          
             listCart.forEach((el) => {
                if (el['title'] === data['title']) {
                    if (el['size'] === data['size']) {
                        const listCartAmount = Number(el['amount'])
                        const dataAmount = Number(data['amount'])

                        el['amount'] = listCartAmount + dataAmount;

                    }
                    else {
           
                    }
                
                }
                else {
                     const cartFake = listCart.find((el2) => {
                              return el['title'] === el2['title']
                          })
                          if (!cartFake) {
                              listCart.push(data)
                          }
                }
            })
           
            let dataSize = listCart.find((el) => {
                return el['title'] === data['title'] && el['size'] === data['size'] 
            })
            if (!dataSize) {
               console.log("da vao")
                listCart.push(data);
            }
            window.localStorage.setItem('cart', JSON.stringify(listCart));
       

      }

    
  } else alert('Bạn chưa chọn size');
});

//lấy giá trị từ localStorage với key=cart
//let itemCart=value
//itemCart.push(data);
//push lại vào localStorage;

//[{},{},{}]
