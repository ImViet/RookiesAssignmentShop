import { Modal, Button } from "react-bootstrap";
import EditProductForm from "../../Form/Product/EditProductForm";
import { putProductAPI } from "../../../api/Product";
function EditProductModal({status, onClose, data}) {
  const handleSubmit = (product)=>{
    putProductAPI(product).then(()=>{
      onClose();
      setTimeout(() => {
        alert("Sửa thành công!!!");
      }, 200);
    }).catch((err)=>{
      setTimeout(() => {
        alert("Sửa thất bại!!!");
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
            Chỉnh sửa
          </Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <EditProductForm data={data} onSubmit={handleSubmit}/>
        </Modal.Body>
        <Modal.Footer>
        <Button variant="secondary" onClick={onClose}>Đóng</Button>
      </Modal.Footer>
      </Modal>
  );
}
export default EditProductModal;
