function attachGradientEvents() {
    const divBox = document.getElementById('gradient');
    const divResult = document.getElementById('result');
  
    divBox.addEventListener('mousemove', calculatePercentage);
    divBox.addEventListener('mouseout', clearResult);
  
    function calculatePercentage(e) {
        let percentage = Math.floor((e.offsetX / (e.target.clientWidth - 1)) * 100);
        divResult.textContent = `${percentage}%`;
    }
  
    function clearResult() {
        divResult.textContent = '';
    }
}