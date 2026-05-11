import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import { getGames } from '../services/gameServices';

function FilterSearch() {
    const [inputValue, setInputValue] = useState("");
    const [allGames, setAllGames] = useState([]);
    const navigate = useNavigate();

    useEffect(() => {
        getGames().then(data => setAllGames(data));
    }, []);

    const filteredGames = allGames.filter((game) =>
        game.titulo.toLowerCase().includes(inputValue.toLowerCase())
    );

    return (
        <div className='search-container'>
            <input
                type="search"
                value={inputValue}
                placeholder="Buscar juego..."
                onChange={(e) => setInputValue(e.target.value)}
                className='search-input'
            />

            {inputValue !== "" && (
                <ul className='search-results'>
                    {filteredGames.length > 0 ? (
                        filteredGames.map((game) => (
                            <li
                                key={game.id}
                                className='search-result-item'
                                onClick={() => navigate(`/game/${game.id}`)}
                            >
                                <span className='result-titulo'>{game.titulo}</span>
                                <span className='result-precio'>${game.precio}</span>
                            </li>
                        ))
                    ) : (
                        <li className='no-results'>No se encontraron juegos.</li>
                    )}
                </ul>
            )}
        </div>
    );
}

export default FilterSearch;
