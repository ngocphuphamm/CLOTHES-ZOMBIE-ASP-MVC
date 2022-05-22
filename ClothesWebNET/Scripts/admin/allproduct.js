

    (function ($) {
        'use strict';






        //   jquey database

        var table = $('#table-product').DataTable();

        /*Nút update*/
        $('#table-product tbody').on('click', 'tr .btn-update', function () {
            let td = $(this).parent();
            let tr = td.parent();
            var data = table.row(tr).data();
            //set data cho modal
            //data[0123456
            $('.pid').val(data[0])
            $('.pname').val(data[1])
            $('.ptype').val(data[3])
            $('.pprice').val(data[4])
            $('.pm').val(data[5])
            $('.pl').val(data[6])
            $('.pxl').val(data[7])
            $('.pdes').val('Chưa cập nhật')
            $('.modal-update').css('display', 'flex');
        });

        /*Nút xóa*/
        $('#table-product tbody').on('click', 'tr .btn-delete', function () {
            let td = $(this).parent();
            let tr = td.parent();
            var data = table.row(tr).data();

            let idProduct = data[0];
            window.location.href = `/Admin/Products/Delete/${idProduct}`
        });



        /*ẩn khi click ra ngoài*/
        $('.modal__overplay').click(function () {
            $('.modal-cus').toggle();
        });
    })(jQuery);

