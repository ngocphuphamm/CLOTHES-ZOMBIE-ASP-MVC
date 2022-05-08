//lấy thông tin sản phẩm và chuyển hướng qua detail
let products = document.querySelectorAll('.products .grid__col-3');
let data = [];
products.forEach((product) => {
  product.addEventListener('click', (e) => {
    //lấy ảnh
    data = [];
    let listImg = [];
    let imgs = product.querySelectorAll('.product-img');
    imgs.forEach((img) => {
      listImg.push(img.src);
    });

    let title = product.querySelector('.product-title').textContent.trim();
    let price = product.querySelector('.product-price').textContent.trim();
    data.push({ listImg, title, price });

    //code chuyển hướng qua detail + data
    console.log(data);
  });
});
