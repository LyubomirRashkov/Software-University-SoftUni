function solve() {
  const textarea = document.getElementById('input');
  const divOutput = document.getElementById('output');

  let text = textarea.value;

  let sentences = text.split('.');
  sentences = sentences.map((s) => s.trim());
  sentences.pop();

  while (sentences.length > 0) {
    let currentSentences = sentences.splice(0, 3);

    let content = currentSentences.join('.') + '.';

    let paragraph = document.createElement('p');
    paragraph.textContent = content;

    divOutput.appendChild(paragraph);
  }
}