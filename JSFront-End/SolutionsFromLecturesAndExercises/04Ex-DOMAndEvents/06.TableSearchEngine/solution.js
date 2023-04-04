function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);

   function onClick() {
      const input = document.getElementById('searchField');
      const rows = Array.from(document.querySelectorAll('tbody > tr'));

      const pattern = input.value;
      
      for (const row of rows) {     
         if (row.classList.contains('select')) {
            row.classList.remove('select');
         }

         if (row.textContent.includes(pattern)) {
            row.classList.add('select');
         }
      }

      input.value = '';
   }
}