const close = document.getElementById('close');
const open = document.getElementById('open');
const postsContainer = document.getElementById('posts-container');
const loading = document.querySelector('.loader');
const filter = document.getElementById('filter');

let limit = 5;
let page = 1;


//登录框弹出
open.addEventListener('click', () => modal.classList.add('show-modal'));
close.addEventListener('click', () => modal.classList.remove('show-modal'));


//用API获取学院数据
async function getPosts() {
    const res = await fetch(
        `https://localhost:44397/api/institute`
    );

    const data = await res.json();

    return data;
}

//在DOM中展示学院数据
async function showPosts() {
    const gets = await getPosts();

    gets.forEach(get => {
        const getEl = document.createElement('div');
        getEl.classList.add('post');
        getEl.innerHTML = `
      <div class="number"> </div>
      <div class="post-info">
        <h2 class="post-title">${get.name}</h2>
        <p class="post-body">${get.introduction}</p>
      </div>
    `;

        postsContainer.appendChild(getEl);
    });
}


function showLoading() {
    loading.classList.add('show');

    setTimeout(() => {
        loading.classList.remove('show');

        setTimeout(() => {
            page++;
            showPosts();
        }, 300);
    }, 1000);
}


//查找学院
function filterPosts(e) {
    const term = e.target.value.toUpperCase();
    const posts = document.querySelectorAll('.post');

    posts.forEach(post => {
        const title = post.querySelector('.post-title').innerText.toUpperCase();
        const body = post.querySelector('.post-body').innerText.toUpperCase();

        if (title.indexOf(term) > -1 || body.indexOf(term) > -1) {
            post.style.display = 'flex';
        } else {
            post.style.display = 'none';
        }
    });
}

//展示初始数据
showPosts();

window.addEventListener('scroll', () => {
    const { scrollTop, scrollHeight, clientHeight } = document.documentElement;

    if (scrollTop + clientHeight >= scrollHeight - 5) {
        showLoading();
    }
});

filter.addEventListener('input', filterPosts);