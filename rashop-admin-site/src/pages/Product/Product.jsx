import React, { useEffect, useState } from "react";
import {
  Button,
  InputGroup,
  Form,
  Dropdown,
  DropdownButton,
  Col,
  Row,
} from "react-bootstrap";
import { getProductAPI } from "../../api/Product";
import AddProductModal from "../../components/Modal/Product/AddProductModal";
import DetailProductModal from "../../components/Modal/Product/DetailProductModal";
import EditProductModal from "../../components/Modal/Product/EditProductModal";
import DeleteProductModal from "../../components/Modal/Product/DeleteProductModal";
function Product() {
  const [productsData, setProductsData] = useState();
  const [sort, setSort] = useState("0");
  const [query, setQuery] = useState("");
  const [pageIndex, setPageIndex] = useState(1);
  const [showDetailModal, setShowDetailModal] = useState(false);
  const [showAddModal, setShowAddModal] = useState(false);
  const [showEditModal, setShowEditModal] = useState(false);
  const [showDeleteModal, setShowDeleteModal] = useState(false);
  const [current, setCurrent] = useState();
  useEffect(() => {
    getProductAPI(query, pageIndex, sort)
      .then((res) => {
        setProductsData(res);
        console.log("re-render");
      })
      .catch((err) => console.log(err));
  }, [query, pageIndex, sort, showAddModal, showEditModal, showDeleteModal]);

  //Start: Function handle pagination
  function handleNextPage() {
    if (pageIndex < productsData.totalPages) {
      setPageIndex((i) => i + 1);
    }
  }
  function handlePrePage() {
    if (pageIndex > 1) {
      setPageIndex((i) => i - 1);
    }
  }
  //End: Function handle pagination
  return (
    <React.Fragment>
      <InputGroup className="mb-3">
        <Form.Control
          placeholder="Nhập để tìm kiếm..."
          aria-label="Recipient's username"
          aria-describedby="basic-addon2"
          onChange={(e) => {
            setQuery(e.target.value);
            setPageIndex((i) => (i = 1));
          }}
        />
      </InputGroup>
      <Row>
        <Col>
          <DropdownButton
            variant="secondary"
            id="dropdown-item-button"
            title="Sắp xếp"
          >
            <Dropdown.Item
              onClick={() => {
                setSort((s) => "price");
                setPageIndex((i) => (i = 1));
              }}
            >
              Giá tăng dần
            </Dropdown.Item>
            <Dropdown.Item
              as="button"
              onClick={() => {
                setSort((s) => "price_desc");
                setPageIndex((i) => (i = 1));
              }}
            >
              Giá giảm dần
            </Dropdown.Item>
            <Dropdown.Item
              as="button"
              onClick={() => {
                setSort((s) => "name");
                setPageIndex((i) => (i = 1));
              }}
            >
              Tên a-z
            </Dropdown.Item>
            <Dropdown.Item
              as="button"
              onClick={() => {
                setSort((s) => "name_desc");
                setPageIndex((i) => (i = 1));
              }}
            >
              Tên z-a
            </Dropdown.Item>
          </DropdownButton>
        </Col>
        <Col>
          <Button onClick={() => setShowAddModal(true)} variant="success">
            Tạo mới
          </Button>
        </Col>
      </Row>

      <table className="table table-striped table-hover table-boredered">
        <thead>
          <tr>
            <th scope="col">Id</th>
            <th scope="col">Sản phẩm</th>
            <th scope="col">Giá</th>
            <th scope="col">Danh mục</th>
            <th scope="col">Loại SP</th>
            <th scope="col">Ngày tạo</th>
            <th></th>
          </tr>
        </thead>
        <tbody>
          {productsData &&
            productsData.items.map((item) => (
              <tr key={item.productId}>
                <td>{item.productId}</td>
                <td>{item.productName}</td>
                <td>{item.price}</td>
                <td>{item.categoryName}</td>
                <td>{item.subCategoryName}</td>
                <td>{item.dateCreated}</td>
                <td>
                  <Button
                    onClick={() => {
                      setCurrent(item);
                      setShowDetailModal(true);
                    }}
                    variant="outline-primary"
                  >
                    Chi tiết
                  </Button>
                  <Button
                    onClick={() => {
                      setCurrent(item);
                      setShowEditModal(true);
                    }}
                    variant="outline-warning"
                  >
                    Sửa
                  </Button>
                  <Button
                    onClick={() => {
                      setCurrent(item);
                      setShowDeleteModal(true);
                    }}
                    variant="outline-danger"
                  >
                    Xóa
                  </Button>
                </td>
              </tr>
            ))}
        </tbody>

        <Button variant="outline-secondary" onClick={handlePrePage}>
          Trước
        </Button>
        <Button variant="outline-secondary" onClick={handleNextPage}>
          Sau
        </Button>
      </table>
      {/* Add Product Modal  */}
      <AddProductModal
        status={showAddModal}
        onClose={() => setShowAddModal(false)}
      />
      {/* Detail Product Modal */}
      <DetailProductModal
        status={showDetailModal}
        data={current}
        onClose={() => setShowDetailModal(false)}
      />
      {/* Edit Product Modal */}
      <EditProductModal
        status={showEditModal}
        data={current}
        onClose={() => setShowEditModal(false)}
      />
      {/* Delete Product Modal */}
      <DeleteProductModal
        status={showDeleteModal}
        data={current}
        onClose={() => setShowDeleteModal(false)}
      />
    </React.Fragment>
  );
}

export default Product;
