//lấy thông tin sản phẩm và chuyển hướng qua detail


let col = document.querySelectorAll('.grid__col-3');
col.forEach(i => {
    i.addEventListener('click', e => {
        let id = i.querySelector('#idProduct').textContent;
        let url = `/collections/Details/${id}`
        window.location = url;

    })
})