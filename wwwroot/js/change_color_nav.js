$(function () {
    $(document).scroll(function () {
      var $nav = $(".menu");
      $nav.toggleClass('menu-scrolled', $(this).scrollTop() > $nav.height());
    });
  });