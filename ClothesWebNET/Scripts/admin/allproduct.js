(function ($) {
  'use strict';



 
 

  //   jquey database

  var table = $('#table-product').DataTable();
  // get data từng dòng

  $('#table-product tbody').on('click', 'tr .btn-update', function () {
    let td = $(this).parent();
    let tr = td.parent();
    var data = table.row(tr).data();
    //set data cho modal
    //data[0123456
      $('.pid').val(data[0])
      $('.pname').val(data[1])
      $('.ptype').val(data[2])
      $('.pprice').val(data[3])
      $('.pm').val(data[4])
      $('.pl').val(data[5])
      $('.pxl').val(data[6])


   

    $('.modal-update').css('display', 'flex');
  });

  $('.modal__overplay').click(function () {
    $('.modal-cus').toggle();
  });
})(jQuery);
