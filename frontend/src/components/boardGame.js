import apiActions from "../api/api-actions";
import * as constants from "../components/constants";
import gamePiece from "../components/gamePiece";

export default {
    displayBoardGameIndex,
}

function displayBoardGameIndex(boardGames) {
    constants.mainContent.innerHTML = `
    <button id="create"> Create New Board Game </button>
    <section id="boardGameContainer">
        ${boardGames.map((bg) => {
        return `
                <div class="boardGameCard">
                    <h2 id="boardGameTitle">
                        ${bg.name}
                    </h2>
                    <h3 id="gameGenre">
                        ${constants.genreList[bg.genre]}
                    </h3>
                    <p id="playerCount">
                        ${bg.minPlayers} - ${bg.maxPlayers} players
                    </p>
                    <ul id="gamePieceContainer">
                        ${bg.gamePieces.map((gp) => {
                            return `
                                <li>
                                    ${gp.name}
                                </li>
                            `
                        })}
                    </ul>
                    <button class="deleteButton" id="delete-${bg.id}"> Delete </button>
                    <button class="editButton" id="edit-${bg.id}"> Edit </button>
                    <button class="gamePieceButton" id="gp-${bg.id}"> Add Game Piece </button>
                </div>
            `
    }).join('')}
    </section>
    `;
    setupBoardGameIndex();
}

function setupBoardGameIndex() {
    // grab create
    const create = document.getElementById("create");
    // create functionality
    create.addEventListener("click", displayBoardGameCreate);
    // grab delete
    const deleteBtns = Array.from(document.getElementsByClassName("deleteButton"));
    // delete functionality
    deleteBtns.forEach((btn) => {
        btn.addEventListener("click", () => {
            let id = btn.id.split("-")[1]; // quick and dirty way to grab the boardGame ID from the delete button ID we created
            // btn -> html item
            // btn.id -> "delete-2"
            // btn.id.split("-") -> ["delete", "2"]
            // btn.id.split("-")[1] -> "2"
            apiActions.deleteRequest(constants.boardGameURL + id, displayBoardGameIndex);
        });
    });
    // grab edit
    const editBtns = Array.from(document.getElementsByClassName("editButton"));
    // edit functionality
    editBtns.forEach((btn) => {
        btn.addEventListener("click", () => {
            let id = btn.id.split("-")[1]; // quick and dirty way to grab the boardGame ID
            apiActions.getRequest(constants.boardGameURL + id, displayBoardGameEdit);
        });
    });

    //grab gp buttons
    const gamePieceBtns = Array.from(document.getElementsByClassName("gamePieceButton"));
    // add gp button functionality
    gamePieceBtns.forEach((btn) => {
        btn.addEventListener("click", () => {
            let id = btn.id.split("-")[1]; // quick and dirty way to grab the boardGame ID
            //navigate to a create form for a 'boardgamepiece' 
            // wrap this in an API call
            apiActions.getRequest(constants.gamePieceURL, (gamePieces) => {
                console.log(gamePieces);
                gamePiece.displayBoardGamePieceCreate(gamePieces, id);
            })
        });
    });
}

function displayBoardGameCreate() {
    constants.mainContent.innerHTML = `
        <button id="backButton"> Back </button>
        <h1>
            Create
        </h1>
        <section id="createForm">
            <h4>
                Name:
            </h4>
            <input type="text" id="bgName">
            <h4>
                Minimum Number of Players:
            </h4>
            <input id="bgMin" type="number" min="1" max="10" step="1" value=2>
            <h4>
                Maximum Number of Players:
            </h4>
            <input id="bgMax" type="number" min="1" max="10" step="1" value=4>
            <h4>
                Genre:
            </h4>
            <select id="bgGenre">
                ${constants.genreList.map((g) => {
                    return `
                    <option value=${constants.genreList.indexOf(g)}>
                        ${g}
                    </option> 
                `}).join("")}
            </select>
            <h4>
                Is the Game Co-Op?
            </h4>
            <input type="checkbox" id="bgCoop" value="true">
            <button id="submitButton"> Submit Form </button>
        </section>
        `;
    setupBoardGameCreate();
}

function setupBoardGameCreate() {
    // grab back button
    let backBtn = document.getElementById("backButton");
    //back button functionality
    backBtn.addEventListener("click", () => {
        apiActions.getRequest(constants.boardGameURL, displayBoardGameIndex);
    })

    let submitBtn = document.getElementById("submitButton");
    submitBtn.addEventListener("click", () => {
        let newBg = {
            Name: document.getElementById("bgName").value,
            MinPlayers: parseInt(document.getElementById("bgMin").value),
            MaxPlayers: parseInt(document.getElementById("bgMax").value),
            Genre: parseInt(document.getElementById("bgGenre").value),
            IsCoop: document.getElementById("bgCoop").checked,
            GamePieces: []
        }
        console.log(newBg);
        apiActions.postRequest(constants.boardGameURL, displayBoardGameIndex, newBg);
    })
}

function displayBoardGameEdit(boardGame) {
    constants.mainContent.innerHTML = `
        <button id="backButton"> Back </button>
        <h1>
            Edit
        </h1>
        <section id="editForm">
            <input type="hidden" id="bgId" value=${boardGame.id}>
            <h4>
                Name:
            </h4>
            <input type="text" id="bgName">
            <h4>
                Minimum Number of Players:
            </h4>
            <input id="bgMin" type="number" min="1" max="10" step="1" value=${boardGame.minPlayers}>
            <h4>
                Maximum Number of Players:
            </h4>
            <input id="bgMax" type="number" min="1" max="10" step="1" value=${boardGame.maxPlayers}>
            <h4>
                Genre:
            </h4>
            <select id="bgGenre" value=${boardGame.genre}>
                ${constants.genreList.map((g) => {
                    return `
                    <option value=${constants.genreList.indexOf(g)}>
                        ${g}
                    </option> 
                    `}).join("")}
            </select>
            <h4>
                Is the Game Co-Op?
            </h4>
            <input type="checkbox" id="bgCoop" checked=${boardGame.isCoop}>
            <button id="submitButton"> Submit Form </button>
        </section>
        `;
        document.getElementById("bgName").value = boardGame.name;
    setupBoardGameEdit();
}

function setupBoardGameEdit(){
    // grab back button
    let backBtn = document.getElementById("backButton");
    //back button functionality
    backBtn.addEventListener("click", () => {
        apiActions.getRequest(constants.boardGameURL, displayBoardGameIndex);
    });

    let submitBtn = document.getElementById("submitButton");
    submitBtn.addEventListener("click", () => {
        let editedBg = {
            Id: document.getElementById("bgId").value,
            Name: document.getElementById("bgName").value,
            MinPlayers: parseInt(document.getElementById("bgMin").value),
            MaxPlayers: parseInt(document.getElementById("bgMax").value),
            Genre: parseInt(document.getElementById("bgGenre").value),
            IsCoop: document.getElementById("bgCoop").checked,
            GamePieces: []
        }
        console.log(editedBg);
        apiActions.putRequest(constants.boardGameURL, displayBoardGameIndex, editedBg, document.getElementById("bgId").value);
    });
}

// How do we create a details page?
// What would that look like, using the methods described above as examples?