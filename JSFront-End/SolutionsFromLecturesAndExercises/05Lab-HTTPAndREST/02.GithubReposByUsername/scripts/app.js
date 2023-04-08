function loadRepos() {
	const BASE_URL = "https://api.github.com/users/";

	const input = document.getElementById('username');
	const ulContainer = document.getElementById('repos');

	let inputUsername = input.value;

	ulContainer.innerHTML = '';

	fetch(`${BASE_URL}${inputUsername}/repos`)
		.then((res) => res.json())
		.then((response) => {
			for (const item of response) {
				let { full_name,  html_url} = item;

				let newAnchor = document.createElement('a');
				newAnchor.href = html_url;
				newAnchor.textContent = full_name;

				let newLi = document.createElement('li');
				newLi.appendChild(newAnchor);

				ulContainer.appendChild(newLi);
			}
		})
		.catch((err) => {
			console.error(err);
		});
}

// async function loadRepos() {
// 	const BASE_URL = "https://api.github.com/users/";

// 	const input = document.getElementById('username');
// 	const ulContainer = document.getElementById('repos');

// 	let inputUsername = input.value;

// 	ulContainer.innerHTML = '';

// 	try {
// 		let res = await fetch(`${BASE_URL}${inputUsername}/repos`);
// 		let response = await res.json();

// 		for (const item of response) {
// 			let { full_name, html_url } = item;

// 			let newAnchor = document.createElement('a');
// 			newAnchor.href = html_url;
// 			newAnchor.textContent = full_name;

// 			let newLi = document.createElement('li');
// 			newLi.appendChild(newAnchor);

// 			ulContainer.appendChild(newLi);
// 		}
// 	}
// 	catch (err) {
// 		console.error(err);
// 	}
// }