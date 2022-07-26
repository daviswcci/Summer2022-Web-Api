import * as constants from "../components/constants";

export default {
    displayBoardGameIndex
}

function displayBoardGameIndex(boardGames){
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
                    <button id="delete-${bg.id}"> Delete </button>
                    <button id="edit-${bg.id}"> Edit </button>
                </div>
            `
        }).join('')}
    </section>
    `;
}

function setupBoardGameIndex(){

}