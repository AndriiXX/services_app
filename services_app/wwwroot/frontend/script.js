const url_api = `https://localhost:7122/api/home`
document.addEventListener('DOMContentLoaded', function ()
{
    loadUsers()
})

function loadUsers() {
    fetch(url_api)
        .then(response => response.json())
        .then(data => {
            const users_table = document.getElementById("tbody_users_id")
            users_table.innerHTML = ''
            console.log(data)
            data.forEach(user => {
                users_table.innerHTML +=
                    `
                        <tr>
                            <td>${user.id}</td>
                            <td>${user.firstName}</td>
                            <td>${user.lastName}</td>
                            <td>${user.emailName}</td>
                        </tr>
                    `
            })
        })
}