import { TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { AppComponent } from './app.component';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { CrudService } from './services/CrudService';

describe('AppComponent', () => {
  beforeEach(() => TestBed.configureTestingModule({
    imports: [RouterTestingModule],
    declarations: [AppComponent]
  }));

  it('should create the app', () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.componentInstance;
    expect(app).toBeTruthy();
  });

  it('should render title', () => {
    const fixture = TestBed.createComponent(AppComponent);
    fixture.detectChanges();
    const compiled = fixture.nativeElement as HTMLElement;
    expect(compiled.querySelector('.content span')?.textContent).toContain('ClashRoyaleClanWarsApp app is running!');
  });
});

describe('CrudService', () => {
  let service: CrudService<{id: number, name: string}>;
  let httpMock: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [CrudService]
    });

    service = TestBed.inject(CrudService);
    httpMock = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpMock.verify();
  });

  it('should return an Observable<T[]> when calling getAll()', () => {
    const dummyData = [
      { id: 1, name: 'John' },
      { id: 2, name: 'Doe' }
    ];

    service.getAll().subscribe(data => {
      expect(data.length).toBe(2);
      expect(data).toEqual(dummyData);
    });

    const dummyId = 1;
    const req = httpMock.expectOne(`${service.baseUrl}/${dummyId}`);
    expect(req.request.method).toBe('GET');
    req.flush(dummyData);
  });

  it('should return an Observable<T> when calling getSingle(id)', () => {
    const dummyId = 1;
    const dummyData = { id: dummyId, name: 'John' };

    service.getSingle(dummyId).subscribe(data => {
      expect(data).toEqual(dummyData);
    });

    const req = httpMock.expectOne(`${service.baseUrl}/${dummyId}`);
    expect(req.request.method).toBe('GET');
    req.flush(dummyData);
  });

  it('should return an Observable<T> when calling create(item)', () => {
    const dummyItem = { id: 1, name: 'John' };
    const dummyResponse = { id: 1, name: 'John', createdAt: '2023-09-27T00:00:00Z' };

    service.create(dummyItem).subscribe(response => {
      expect(response).toEqual(dummyResponse);
    });

    const req = httpMock.expectOne(service.baseUrl);
    expect(req.request.method).toBe('POST');
    req.flush(dummyResponse);
  });

  it('should return an Observable<T> when calling update(id, item)', () => {
    const dummyId = 1;
    const dummyItem = { id: dummyId, name: 'John Doe' };
    const dummyResponse = { id: dummyId, name: 'John Doe', updatedAt: '2023-09-27T00:00:00Z' };

    service.update(dummyId, dummyItem).subscribe(response => {
      expect(response).toEqual(dummyResponse);
    });

    const req = httpMock.expectOne(`${service.baseUrl}/${dummyId}`);
    expect(req.request.method).toBe('PUT');
    req.flush(dummyResponse);
  });

  it('should return an Observable<void> when calling delete(id)', () => {
    const dummyId = 1;

    service.delete(dummyId).subscribe(response => {
      expect(response).toBeUndefined();
    });

    const req = httpMock.expectOne(`${service.baseUrl}/${dummyId}`);
    expect(req.request.method).toBe('DELETE');
    req.flush(null);
  });
});