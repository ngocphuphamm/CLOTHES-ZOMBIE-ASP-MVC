

(function ($) {
  'use strict';

  var fullHeight = function () {
    $('.js-fullheight').css('height', $(window).height());
    $(window).resize(function () {
      $('.js-fullheight').css('height', $(window).height());
    });
  };
  fullHeight();

  $('#sidebarCollapse').on('click', function () {
    $('#sidebar').toggleClass('active');
  });

  

   
   
  



  let classActiveLi = document.querySelectorAll('.rvAc li');
  let classActiveA = document.querySelectorAll('.rvAc li a');

  const rmActive = (classActive) => {
    classActive.forEach((item) => {
      if (item.classList.contains('active')) item.classList.remove('active');
    });
  };

  classActiveLi.forEach((item) => {
    item.addEventListener((e) => {
      rmActive(classActiveLi);
      rmActive(classActiveA);
      item.classList.add('active');
    });
  });
})(jQuery);
