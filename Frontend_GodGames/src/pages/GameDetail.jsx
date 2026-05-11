import { useParams, useNavigate } from 'react-router-dom'
import { useState, useEffect } from 'react'
import { getGame } from '../services/gameServices'

function GameDetail() {
    const { id } = useParams()
    const [game, setGame] = useState(null)
    const navigate = useNavigate()

    useEffect(() => {
        getGame(id).then(data => setGame(data))
    }, [id])

    if (!game) return <p style={{ padding: '2rem', color: '#888' }}>Cargando...</p>

    return (
        <div className="game-detail-container">
            <button className='back-btn' onClick={() => navigate(-1)}>← Volver</button>

            <h1 className='titulo'>{game.titulo}</h1>

            <div className='game-detail-content'>
                {game.imagenes?.length > 0 ? (
                    <img
                        src={game.imagenes[0].url}
                        alt={game.titulo}
                        className="game-img-detail"
                    />
                ) : (
                    <div className="placeholder">Sin imagen</div>
                )}

                <div className='info-text'>
                    <p className='game-description'>{game.descripcion}</p>
                    <p className='game-price'>
                        <strong>Precio</strong>
                        ${game.precio}
                    </p>
                </div>
            </div>
        </div>
    )
}

export default GameDetail
