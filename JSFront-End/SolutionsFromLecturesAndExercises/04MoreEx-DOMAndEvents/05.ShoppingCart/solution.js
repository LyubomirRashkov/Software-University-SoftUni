function solve() {
   const addButtons = Array.from(document.getElementsByClassName('add-product'));
   const textarea = Array.from(document.getElementsByTagName('textarea'))[0];
   const checkoutButton = Array.from(document.getElementsByClassName('checkout'))[0];

   addButtons.forEach((b) => b.addEventListener('click', addProductHandler));
   checkoutButton.addEventListener('click', checkHandler);

   let setOfProducts = new Set();
   let totalPrice = 0;

   function addProductHandler(e) {
      const btn = e.currentTarget;

      const divProduct = btn.parentElement.parentElement;

      const divName = Array.from(divProduct.getElementsByClassName('product-title'))[0];
      let productName = divName.textContent;
      setOfProducts.add(productName);

      const divPrice = Array.from(divProduct.getElementsByClassName('product-line-price'))[0];
      let productPrice = Number(divPrice.textContent);
      totalPrice += productPrice;

      textarea.value += `Added ${productName} for ${productPrice.toFixed(2)} to the cart.\n`;
   }

   function checkHandler(e) {
      textarea.value += `You bought ${(Array.from(setOfProducts)).join(', ')} for ${totalPrice.toFixed(2)}.`;

      addButtons.forEach((b) => b.setAttribute('disabled', 'true'));
      e.currentTarget.setAttribute('disabled', 'true');
   }
}