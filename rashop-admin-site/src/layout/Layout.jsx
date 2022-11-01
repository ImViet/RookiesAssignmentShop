import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import SideBar from "./Sidebar/SideBar";
import NavBar from "./Navbar/NavBar";

function Layout() {
    return (
        <Container fluid className="p-0">
            <Row className="p-0 m-0">
                <Col md={2} className="p-0">
                    <SideBar/>
                </Col>
                <Col md={10} className="p-0">
                    <NavBar/>
                </Col>
            </Row>
        </Container>
    );
}

export default Layout;