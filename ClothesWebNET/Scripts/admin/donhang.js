(function ($) {
  'use strict';

  //   jquey database

  var table = $('#table-product').DataTable();

  // cập nhật đơn hàng
  $('#table-product tbody').on('click', 'tr .btn-update', function () {
    let td = $(this).parent();
    let tr = td.parent();
    var data = table.row(tr).data();

    //data[1],2,3

    // set data cho modal cập nhật
    $('.update-customer').val(data[1]);
    $('.update-createAt').val(data[2]);
    let price = data[3].slice(0, 3);
    $('.update-price').val(price);

    $('.update-status').val(data[4]);
    $('.update-updateAt').val(data[5]);

    // Hiện modal cập nhật
    $('.modal-update').css('display', 'flex');
  });

  $('.mdu').click(function () {
    $('.modal-update').toggle();
  });

  $('.btn-detail').click(function () {
    window.location.href = '/chitietdonhang.html';
  });
})(jQuery);
