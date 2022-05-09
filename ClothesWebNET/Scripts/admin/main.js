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

  new Chartist.Line(
    '#chart-with-area',
    {
      labels: [
        'Thứ 2',
        'Thứ 3',
        'Thứ 4',
        'Thứ 5',
        'Thứ 6',
        'Thứ 7',
        'Chủ nhật',
      ],
      series: [[20, 30, 50, 40, 30, 60, 25]],
    },
    {
      low: 0,
      showArea: true,
      // plugins: [Chartist.plugins.tooltip()],
    }
  );

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
