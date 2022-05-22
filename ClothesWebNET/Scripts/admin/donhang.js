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
      $('.bid').val(data[0]);
      $('.bname').val(data[1]);
   
      $('.bphone').val(data[2]);

      $('.baddress').val(data[3]);
      $('.btotal').val(data[4]);
      $('.bpttt').val(data[5]);
      $('.bstatus').val(data[6]);
      

    // Hiện modal cập nhật
    $('.modal-update').css('display', 'flex');
  });

  $('.mdu').click(function () {
    $('.modal-update').toggle();
  });

    $('#table-product tbody').on('click', 'tr .btn-detail', function () {
        let td = $(this).parent();
        let tr = td.parent();
        var data = table.row(tr).data();
        window.location.href = `/Admin/Bills/Details/${data[0]}`;
       
    });
 
})(jQuery);
