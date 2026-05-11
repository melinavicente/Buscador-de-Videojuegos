import FilterSearch from './SearchFilter'

function Home() {
    return (
        <div className='home-container'>
            <h1 className='titulo'>GodGames</h1>
            <p className='subtitulo'>Encontrá tu próximo juego favorito</p>
            <FilterSearch />
        </div>
    )
}

export default Home
