function solve() {
  const inputText = document.getElementById('text');
  const inputNamingConvention = document.getElementById('naming-convention');
  const btn = document.querySelector('input[type="button"]');
  const spanResult = document.getElementById('result');

  let text = inputText.value;
  text = text.toLowerCase();
  let words = text.split(' ');

  let namingConvention = inputNamingConvention.value;

  let output = '';

  if (namingConvention === 'Camel Case') {
    for (let i = 1; i < words.length; i++) {
      words[i] = transformCasing(words[i]);
    }

    output = words.join('');
  } else if (namingConvention === 'Pascal Case') {
    words = words.map((w) => w = transformCasing(w));

    output = words.join('');
  } else {
    output = 'Error!';
  }

  spanResult.textContent = output;

  function transformCasing(word) {
    let symbols = word.split('');
    symbols[0] = symbols[0].toUpperCase();

    word = symbols.join('');

    return word;
  }
}