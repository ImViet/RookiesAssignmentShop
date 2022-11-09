import { Modal, Button } from "react-bootstrap";
import AddProductForm from "../../Form/Product/AddProductForm";
import { postProductAPI } from "../../../api/Product";
function AddProductModal({status, onClose}) {
  const handleSubmit = (product)=>{
    postProductAPI(product).then(()=>{
    onClose();
    setTimeout(() => {
      alert("Thêm thành công!!!");
    }, 200);
  })
    .catch((err)=>{
      setTimeout(() => {
        alert("Thêm thất bại!!!");
      }, 200);
      console.log(err)});
  }
  return (
    <Modal
        show={status}
        dialogClassName="modal-90w"
        size="lg"
        aria-labelledby="example-custom-modal-styling-title"
      >
        <Modal.Header>
          <Modal.Title id="example-custom-modal-styling-title">
            Thêm mới
          </Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <AddProductForm onSubmit={handleSubmit}/>
        </Modal.Body>
        <Modal.Footer>
        <Button variant="secondary" onClick={onClose}>Đóng</Button>
      </Modal.Footer>
      </Modal>
  );
}
export default AddProductModal;
