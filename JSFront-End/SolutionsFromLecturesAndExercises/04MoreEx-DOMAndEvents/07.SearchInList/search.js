function search() {
   const input = document.getElementById('searchText');
   const liItems = Array.from(document.getElementsByTagName('li'));
   const divResult = document.getElementById('result');

   liItems.forEach((li) => li.style.textDecoration = 'none');
   liItems.forEach((li) => li.style.fontWeight = '400');

   let searchPattern = input.value;

   let matchesCount = 0;

   for (let i = 0; i < liItems.length; i++) {
      if (liItems[i].textContent.includes(searchPattern)) {
         liItems[i].style.textDecoration = 'underline';
         liItems[i].style.fontWeight = 'bold';

         matchesCount++;
      }      
   }

   divResult.textContent = `${matchesCount} matches found`;
}