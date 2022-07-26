import * as constants from "../components/constants";
import apiActions from "../api/api-actions";
import boardGame from "./boardGame";

export default {
    displayBoardGamePieceCreate
}

function displayBoardGamePieceCreate(gamePieces, id){
    // grab a boardgame by id
    // use that data to populate our HTML
    constants.mainContent.innerHTML = `
    <button id="backButton"> Back </button>
        <h1>
            Add a Game Piece to Board Game
        </h1>
        <section id="createForm">
            <input type="hidden" id="bgId" value=${id}>
            <select id="gpId">
                ${gamePieces.map((gp) => {
                    return `
                    <option value=${gp.id}>
                        ${gp.name}
                    </option> 
                `}).join("")}
            </select>
            <button id="submitButton"> Submit Form </button>
        </section>
        `;
    //console.log(id);
    setupBoardGamePieceCreate();
}

function setupBoardGamePieceCreate(){
    // grab back button
    let backBtn = document.getElementById("backButton");
    //back button functionality
    backBtn.addEventListener("click", () => {
        apiActions.getRequest(constants.boardGameURL, boardGame.displayBoardGameIndex);
    })

    let submitBtn = document.getElementById("submitButton");
    submitBtn.addEventListener("click", () => {
        let newBgp = {
            Id: 0,
            BoardGameId: parseInt(document.getElementById("bgId").value),
            GamePieceId: parseInt(document.getElementById("gpId").value),
        }
        console.log(newBgp);
        apiActions.postRequest(constants.boardGamePieceURL, boardGame.displayBoardGameIndex, newBgp);
    })
}