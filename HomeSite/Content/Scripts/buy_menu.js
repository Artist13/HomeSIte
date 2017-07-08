window.onscroll = function () {
    var scrolled = window.pageYOffset || document.documentElement.scrollTop;
    var start = 626;
  var length = parseInt(getComputedStyle(document.getElementById('container_price')).height) - 51;
  var buy = document.getElementById('buy');
  var finish = start + length - parseInt(getComputedStyle(buy).height) - 35;
  if (scrolled < start) {
      buy.style.position = "absolute";
      buy.style.top = "51px";
  };
  if (scrolled > start) {
      buy.style.position = "fixed";
      buy.style.top = "2px";
  };
  if (scrolled > finish) {
      buy.style.position = "absolute";
      buy.style.top = 51 + length - parseInt(getComputedStyle(buy).height) - 35 + "px";
  }
}
