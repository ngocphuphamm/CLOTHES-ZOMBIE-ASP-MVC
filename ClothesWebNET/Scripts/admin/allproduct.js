

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
            $('.pid').val(data[1])
            $('.pname').val(data[2])
            $('.ptype').val(data[4])
            $('.pprice').val(data[5])
            $('.pm').val(data[6])
            $('.pl').val(data[7])
            $('.pxl').val(data[8])
            $('.pdes').val('Chưa cập nhật')
            $('.modal-update').css('display', 'flex');
        });

        /*Nút xóa*/
        $('#table-product tbody').on('click', 'tr .btn-delete', function () {
            let td = $(this).parent();
            let tr = td.parent();
            var data = table.row(tr).data();

            let idProduct = data[1];
   


            $.ajax(`/Admin/Products/Delete/${idProduct}`, {
                data: idProduct,
                dataType: 'json',
                method: 'Post',
                success: function (res) {
                        alert("Xóa sản phẩm thành công");
                        window.location.reload();
                    
                }

            })

        });



        /*ẩn khi click ra ngoài*/
        $('.modal__overplay').click(function () {
            $('.modal-cus').toggle();
        });
    })(jQuery);

