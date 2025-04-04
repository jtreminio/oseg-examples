package oseg.namsor_examples

import app.namsor.client.infrastructure.*
import app.namsor.client.apis.*
import app.namsor.client.models.*

import java.io.File
import java.time.LocalDate
import java.time.OffsetDateTime
import kotlin.collections.ArrayList
import kotlin.collections.List
import kotlin.collections.Map
import com.squareup.moshi.adapter

@ExperimentalStdlibApi
class DiasporaFullBatchExample
{
    fun diasporaFullBatch()
    {
        ApiClient.apiKey["X-API-KEY"] = "YOUR_API_KEY"

        val personalNames1 = PersonalNameGeoIn(
            id = "0d7d6417-0bbb-4205-951d-b3473f605b56",
            name = "Keith Haring",
            countryIso2 = "US",
        )

        val personalNames = arrayListOf<PersonalNameGeoIn>(
            personalNames1,
        )

        val batchPersonalNameGeoIn = BatchPersonalNameGeoIn(
            personalNames = personalNames,
        )

        try
        {
            val response = PersonalApi().diasporaFullBatch(
                batchPersonalNameGeoIn = batchPersonalNameGeoIn,
            )

            println(response)
        } catch (e: ClientException) {
            println("4xx response calling PersonalApi#diasporaFullBatch")
            e.printStackTrace()
        } catch (e: ServerException) {
            println("5xx response calling PersonalApi#diasporaFullBatch")
            e.printStackTrace()
        }
    }
}
