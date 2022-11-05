import Container from 'react-bootstrap/Container';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import SideBar from "./Sidebar/SideBar";
import NavBar from "./Navbar/NavBar";
import { Routes, Route } from "react-router-dom";
import Product from '../pages/Product/Product';
import Category from '../pages/Category/Category';
import SubCategory from '../pages/SubCategory/SubCategory';
function Layout() {
    return (
        <Container fluid className="p-0 h-100">
            <Row className="p-0 m-0">
                <Col md={2} className="p-0">
                    <SideBar />
                </Col>
                <Col md={10} className="p-0">
                    <Row className="m-0">
                        <NavBar />
                        <Routes>
                            <Route path='/product' element={<Product/>} />
                            <Route path='/category' element={<Category/>} />
                            <Route path='/subcategory' element={<SubCategory/>} />
                        </Routes>
                    </Row>
                </Col>
            </Row>
        </Container>
    );
}

export default Layout;