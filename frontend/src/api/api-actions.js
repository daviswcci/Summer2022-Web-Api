export default {
    getRequest,
    putRequest,
    postRequest,
    deleteRequest
}

function getRequest(location, callback){
    let settings = {
        method: "GET",
        headers: {
            "Content-Type": "application/json"
        }
    }
    fetch(location, settings)
    .then((response) => {
        return response.json();
    })
    .then((data) => {
        callback(data);
    })
    .catch((err) => {
        console.log(err);
    });
}

function putRequest(location, callback, requestBody, id){
    let settings = {
        method: "PUT",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(requestBody)
    }
    fetch(location + id, settings)
    .then((response) => {
        return response.json();
    })
    .then((data) => {
        callback(data);
    })
    .catch((err) => {
        console.log(err);
    });
}

function postRequest(location, callback, requestBody){
    let settings = {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify(requestBody)
    }
    fetch(location, settings)
    .then((response) => {
        return response.json();
    })
    .then((data) => {
        callback(data);
    })
    .catch((err) => {
        console.log(err);
    });
}

function deleteRequest(location, callback){
    let settings = {
        method: "DELETE",
        headers: {
            "Content-Type": "application/json"
        }
    }
    fetch(location, settings)
    .then((response) => {
        return response.json();
    })
    .then((data) => {
        callback(data);
    })
    .catch((err) => {
        console.log(err);
    });
}