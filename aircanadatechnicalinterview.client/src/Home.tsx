import Book from "./Components/Book.tsx";
import AuthorizeView, { AuthorizedUser } from "./Components/AuthorizedView.tsx";
function Home() {
    return (<AuthorizeView>
        <AuthorizedUser value="email"></AuthorizedUser>
        <Book></Book>
    </AuthorizeView>);
}

export default Home;