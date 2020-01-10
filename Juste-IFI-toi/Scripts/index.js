document.querySelectorAll(".btnUp").forEach(value => {
    value.addEventListener("click", function (e){
        let id = e.currentTarget.getAttribute("accesskey");
        console.log(id);
        axios.get("localhost:5000/Retard/" + id +"/Up").then();
    });
});

document.querySelectorAll(".btnDown").forEach(value => {
    value.addEventListener("click", function (e){
        let id = e.currentTarget.getAttribute("accesskey");
        console.log(id);
        axios.get("localhost:5000/Retard/" + id +"/Down").then();
    });
});

