function solve() {
  const buttons = Array.from(document.getElementsByClassName('answer-wrap'));
  const sections = Array.from(document.getElementsByTagName('section'));

  buttons.forEach((b) => b.addEventListener('click', answerQuestion));

  let rightAnswers = 0;

  function answerQuestion(e) {
    let btn = e.currentTarget;

    let numberOfQuestion = getNumberOfQuestion(btn);

    let currentSection = sections[numberOfQuestion - 1];
    currentSection.style.display = 'none';

    if (ifAnswerIsCorrect(btn)) {
      rightAnswers++;
    }

    if (numberOfQuestion !== 3) {
      let nextSection = sections[numberOfQuestion];
      nextSection.style.display = 'block';
    } else {
      const ulResultContainer = document.getElementById('results');
      const resultContainer = (Array.from(ulResultContainer.getElementsByTagName('h1')))[0];

      let output = '';

      if (rightAnswers === 3) {
        output = 'You are recognized as top JavaScript fan!';
      } else {
        output = `You have ${rightAnswers} right answers`;
      }

      ulResultContainer.style.display = 'block';
      resultContainer.textContent = output;
    }
  }

  function getNumberOfQuestion(btn) {
    const ulContainer = btn.parentElement.parentElement;
    const liQuestion = Array.from(ulContainer.children)[0];

    let question = (Array.from(liQuestion.getElementsByTagName('h2'))[0]).textContent;

    let [questionNumber, _questionText] = question.split(':');
    let [_name, number] = questionNumber.split('#');
    number = Number(number);

    return number;
  }

  function ifAnswerIsCorrect(btn) {
    let answerText = (Array.from(btn.children))[0].textContent;

    if (answerText === 'onclick'
      || answerText === 'JSON.stringify()'
      || answerText === 'A programming API for HTML and XML documents') {
        return true;
      }

    return false;
  }
}