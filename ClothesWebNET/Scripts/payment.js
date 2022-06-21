let checkBoxPayment = document.querySelectorAll('.form-info input');
let content = document.querySelectorAll('.payment-cus-content');
checkBoxPayment.forEach((i) => {
  let a = i.parentElement;
  let b = a.parentElement;
  let c = b.querySelector('.payment-cus-content');
  i.addEventListener('change', (e) => {
    if (i.checked) {
      removeCheckedContent(content);
      c.style.display = 'block';
    }
  });
});

const removeCheckedContent = (content) => {
  content.forEach((i) => {
    if (i.style.display === 'block') i.style.display = 'none';
  });
};
