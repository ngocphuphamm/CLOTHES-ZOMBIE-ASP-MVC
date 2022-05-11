let totals = document.querySelectorAll('.total-money'); //giá khi bấm tăng giảm số lượng (ở cart.html và detail.html)
let prices = document.querySelectorAll('.info-price'); //giá tiền sản phẩm
let btnMinus = document.querySelectorAll('.button-minus'); //nút giảm số lượng
let btnAdd = document.querySelectorAll('.button-add'); //nút tăng
let amounts = document.querySelectorAll('.input-amout'); //ô nhập số lượng
let allMoneyTotals = document.querySelector('.info-total-money'); //tổng tiền của tất cả sản phẩm
let moneyTotals = document.querySelectorAll('.cart-product-item .total-money'); //giá khi bấm tăng giảm số lượng (ở cart.html)

//5830000=>5,830,000₫
const commaSeparator = (money) => {
    let res = [...money];
    let count = 0;
    for (let i = res.length - 1; i >= 0; i--) {
        count++;
        if (count == 3) {
            if (i != 0) {
                res[i] = ',' + res[i];
                count = 0;
            }
        }
    }
    return res.join('') + '₫';
};

//5,830,000₫ ==>5830000 ==>int
const removeComma = (money) => {
    money = parseInt(money.slice(0, money.length - 1).replaceAll(',', ''));
    // console.log(money);
    return money;
};




//Thêm/bớt sản phẩm (cart.html & detail.html)
for (let i = 0; i < prices.length; i++) {
    let money = removeComma(prices[i].textContent.trim());
    let amount = parseInt(amounts[i].value);

    //Trước khi tăng giảm: tổng tiền 1 sản phẩm = giá tiền 1 sản phẩm (cart.html)
    if (moneyTotals[i]) {
        moneyTotals[i].textContent = prices[i].textContent;
  ;
    }

    btnMinus[i].addEventListener('click', (e) => {
        if (amount > 1) {
            amount--;
            amounts[i].value = amount;


      
        }
    });

    btnAdd[i].addEventListener('click', (e) => {
        amount++;
        amounts[i].value = amount;


  
    });
}